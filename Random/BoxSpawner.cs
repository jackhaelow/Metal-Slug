using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box;
    public Transform boxSpawner;
    public float minBoxTime,maxBoxTime;

   void Start()
   {
      Invoke("BoxSpawn",Random.Range(minBoxTime,maxBoxTime));
   }

   void BoxSpawn()
   {
       Instantiate(box,boxSpawner.position,boxSpawner.rotation);
       Invoke("BoxSpawn",Random.Range(minBoxTime,maxBoxTime));
   }
}
