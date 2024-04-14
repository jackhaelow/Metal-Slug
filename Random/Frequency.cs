using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frequency : MonoBehaviour
{
     private Rigidbody2D rb;
     public float speed = 2f;
  
    public float destroyByTime = 1f;
    void Start()
    {
        Destroy(gameObject,destroyByTime);
        rb = GetComponent<Rigidbody2D>();
    }
    

   void Update()
    {
        rb.velocity =  Vector2.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        Destroy(gameObject);
    }
}
