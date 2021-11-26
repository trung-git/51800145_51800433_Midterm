using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 4.5f;
    [SerializeField] private AudioClip EnemyDie;
    // Update is called once per frame
    void Update()
    {
      transform.position += transform.right * Time.deltaTime * speed;
    }
    private void OnCollisionEnter2D(Collision2D other) {
      Destroy(gameObject);
      if (other.gameObject.name == "Enemy")
      {
        SoundManager.instance.PlaySound(EnemyDie);
        other.gameObject.GetComponent<Animator>().SetTrigger("Die");
      }
    }
}
