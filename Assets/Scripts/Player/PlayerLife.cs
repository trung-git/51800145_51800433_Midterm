using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
  [SerializeField] private AudioClip PlayerDie;
  [SerializeField] private AudioClip PlayerWin;
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
    if (other.gameObject.CompareTag("CheckPoint"))
    {
      Win();
      Scene scene = new Scene(SceneManager.GetActiveScene().name,GetComponent<PlayerController>().HitCount,GetComponent<ItemCollectController>().countItems);
      SaveSystem.SaveData(scene);
    }
  }
  public void Die()
  {
    SoundManager.instance.PlaySound(PlayerDie);
    anim.SetTrigger("Die");
    rb.bodyType = RigidbodyType2D.Static;
    gameObject.GetComponent<PlayerController>().SetDie();
  }
  void restartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
  void Win()
  {
    SoundManager.instance.PlaySound(PlayerWin);
    GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Animator>().SetTrigger("CheckWin");
    anim.SetTrigger("Win");
    rb.bodyType = RigidbodyType2D.Static;
    gameObject.GetComponent<PlayerController>().SetDie();
  }
  void nextLevel()
  {
    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    SceneManager.LoadScene("End");
  }
}
