using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private AudioClip Attack;

    [SerializeField] private float attackCooldown;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float colliderDistance;
    private float cooldownTimer = Mathf.Infinity;
    private Rigidbody2D rb;

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isDead())
            {

                if (cooldownTimer >= attackCooldown)
                {
                    cooldownTimer = 0;
                    anim.SetBool("Moving", false);
                    anim.SetTrigger("Attack1");
                    SoundManager.instance.PlaySound(Attack);
                }
            }
        }
        // else
        // {

        //   anim.SetBool("Moving",true);
        // }


    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isDead())
        {
            Debug.Log("DAMAGE");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>().Die();
        }
    }

    private void Dead()
    {
        anim.SetBool("Moving", false);
        Destroy(transform.parent.gameObject);

    }
}
