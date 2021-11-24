using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
  private Animator anim;
  private Rigidbody2D rb;
  // Start is called before the first frame update
  void Start()
  {
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Trap"))
    {
      Die();
    }
  }
  void Die()
  {
    anim.SetTrigger("Die");
    rb.bodyType = RigidbodyType2D.Static;
    gameObject.GetComponent<PlayerMovement>().SetDie();
  }
  void restartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
