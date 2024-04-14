using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
 
 [RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour
{
    public float speed = 2f;
    public float rotateSpeed = 200f;
    public GameObject explosive;
  private Transform target;

  private Rigidbody2D rb;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
       target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

  
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
       float rotateAmount = Vector3.Cross(direction,transform.right).z;
        rb.velocity = transform.right * speed;
       rb.angularVelocity = -rotateAmount * rotateSpeed;
    }
   
   private void OnTriggerEnter2D(Collider2D collider)
   {
        if(collider.tag == "Enemy")
        {
            Instantiate(explosive,transform.position,transform.rotation);
            Destroy(gameObject);
        }
   }

}
