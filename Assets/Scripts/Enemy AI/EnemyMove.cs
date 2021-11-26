using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
  
  [SerializeField] private GameObject[] points;
  private int currentPoint = 0;
  [SerializeField] private float speed = 2f;
  private Animator anim;
  private void Awake() {
    transform.rotation = Quaternion.Euler(0, 180, 0);
    
  }
  private void Start() {
    anim = GetComponent<Animator>();
    anim.SetBool("Moving",true);
  }
  void Update()
  {
    if(anim.GetBool("Moving"))
    {
      if (Vector2.Distance(points[currentPoint].transform.position, transform.position) < .1f)
    {
      currentPoint++;
      if (currentPoint >= points.Length)
      {
        currentPoint = 0;
      }
      transform.rotation = currentPoint == 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }
    transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].transform.position,Time.deltaTime * speed);
    }
    
  }
}
