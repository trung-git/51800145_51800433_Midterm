using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3(playerTransform.position.x,playerTransform.position.y,transform.position.z);
      //transform.position = new Vector3( Mathf.Clamp(playerTransform.position.x,-3.5f, 48.5f),Mathf.Clamp(playerTransform.position.y,-6.35f, -0.6f), transform.position.z);
    }
}
