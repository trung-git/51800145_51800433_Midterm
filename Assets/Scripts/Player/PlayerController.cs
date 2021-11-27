using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
  [SerializeField] private AudioClip FireHit;
  [SerializeField] private AudioClip Jump;
  [SerializeField]
  private bool isDie = false;
  public ParticleSystem dust;
  public ProjectileBehavior projectile;
  public Transform LanchOffset;
  private Rigidbody2D rb;
  private Animator anim;
  private SpriteRenderer sprite;

  [SerializeField]
  private float JumpForce = 1;

  [SerializeField]
  private float MovementSpeed = 1;
  private float inputX;
  private enum MoveState { Idle, Run, Jump, Fall };
  
  [SerializeField]
  public int HitCount = 0;
  public Text txtHit;
  void Start()
  {
      rb = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
      sprite = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    if(!isDie)
    {
      inputX = Input.GetAxisRaw("Horizontal");
      //rb.velocity = new Vector2(inputX * MovementSpeed, rb.velocity.y);
      if (Input.GetAxisRaw("Vertical") > .1f && Mathf.Abs(rb.velocity.y) < 0.001f)
      {
        CreateDust();
        rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        SoundManager.instance.PlaySound(Jump);
          //rb.velocity = new Vector2(rb.velocity.x, JumpForce);
      }

      UpdateAniamtionMovement();
      //
      if (!Mathf.Approximately(0, inputX))
      {
          transform.rotation = inputX < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
      }
      //
      if (Input.GetButtonDown("Jump"))
      {
        if (HitCount > 0)
        {
        HitCount--;
        Debug.Log("Hit");
        Instantiate(projectile, LanchOffset.position, transform.rotation);
        SoundManager.instance.PlaySound(FireHit);
        }
      }
    }
    txtHit.text = "Hit: "+ HitCount;
  }
  void FixedUpdate() {
    if (!isDie)
    {
    transform.position += new Vector3(inputX,0,0) * Time.deltaTime * MovementSpeed;

    }
  }
  void UpdateAniamtionMovement()
  {
      MoveState state;
      if (inputX > 0f)
      {
          state = MoveState.Run;
          // sprite.flipX = false;
          // transform.Rotate(0, 0.0f, 0.0f, Space.Self);
      }
      else if (inputX < 0f)
      {
          state = MoveState.Run;
          // sprite.flipX = true;
          // transform.Rotate(0, 180.0f, 0.0f, Space.Self);
      }
      else
      {
          state = MoveState.Idle;
      }

      if (rb.velocity.y > .1f)
      {
          state = MoveState.Jump;
      }
      else if (rb.velocity.y < -.1f)
      {
          state = MoveState.Fall;
      }

      anim.SetInteger("State", (int)state);
  }
  void CreateDust()
  {
    dust.Play();
  }
  public void SetDie()
  {
    isDie = true;
  }
  public bool isDead()
  {
    return isDie;
  }
}
