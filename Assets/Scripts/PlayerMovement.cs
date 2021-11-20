using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public ProjectileBehavior projectileBehavior;
  public Transform LanchOffset;
  private Rigidbody2D rb;
  private Animator anim;
  private SpriteRenderer sprite;
  
  [SerializeField] 
  private float JumpForce = 1;

  [SerializeField] 
  private float MovementSpeed = 1;
  private float inputX;
  private enum MoveState{Idle,Run,Jump,Fall};
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sprite = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    inputX = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(inputX * MovementSpeed, rb.velocity.y);
    if (Input.GetAxisRaw("Vertical") > .1f && Mathf.Abs(rb.velocity.y) < 0.001f)
    {
      //rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
      rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }

    UpdateAniamtionMovement();

    if (Input.GetButtonDown("Jump"))
    {
      Debug.Log("Hit");
      Instantiate(projectileBehavior, LanchOffset.position, transform.rotation);
    }
  }
  // void FixedUpdate() {
  //   transform.position += new Vector3(inputX,0,0) * Time.deltaTime * MovementSpeed;
  // }
  void UpdateAniamtionMovement(){
    MoveState state;
    if (inputX > 0f)
    {
      state = MoveState.Run;
      sprite.flipX = false;
    }
    else if (inputX < 0f)
    {
      state = MoveState.Run;
      sprite.flipX = true;
    }
    else {
      state = MoveState.Idle;
    }

    if (rb.velocity.y > .1f){
      state = MoveState.Jump;
    }
    else if (rb.velocity.y < -.1f){
      state = MoveState.Fall;
    }

    anim.SetInteger("State",(int)state);
  }
}
