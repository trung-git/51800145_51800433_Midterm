using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformHorizontal : MonoBehaviour
{
  [SerializeField] private GameObject[] points;
  private int currentPoint = 0;
  [SerializeField] private float speed = 2f;
  
  // Update is called once per frame
  void Update()
  {
    if (Vector2.Distance(points[currentPoint].transform.position, transform.position) < .1f)
    {
      currentPoint++;
      if (currentPoint >= points.Length)
      {
        currentPoint = 0;
      }
    }
    transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].transform.position,Time.deltaTime * speed);
      
  }
}
