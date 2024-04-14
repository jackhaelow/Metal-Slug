using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public float followSpeed;
   public float yOffset =1f;
   public float xOffset;
   public Transform target;
     
    void Update()
    {
        transform.position = new Vector3(target.position.x + xOffset,target.position.y + yOffset,transform.position.z);
        
    }
}
