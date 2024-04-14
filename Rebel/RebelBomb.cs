using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebelBomb : MonoBehaviour
{
   public float speed = 10f;
   public GameObject explode;
   
   public float destroyByTime = 1f;


    void Start()
    {
        Destroy(gameObject,destroyByTime);
    }

   
    void Update()
    {
       transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

     private void OnCollisionEnter2D(Collision2D other)
    {


        Instantiate(explode,transform.position,transform.rotation);

        Destroy(gameObject);
    }
}
