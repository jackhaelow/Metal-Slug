using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
   private GameObject player;
      public GameObject explode;
    private Rigidbody2D rb;
    public float force;

        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x,direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y,-direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + -90f);

        
    }
     private void OnCollisionEnter2D(Collision2D collision)
   {
      Instantiate(explode,transform.position,transform.rotation);
        Destroy(gameObject);
   }

}
