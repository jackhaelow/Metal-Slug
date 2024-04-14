using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    public int damage = 1;
    public float destroyByTime = 1f;
    void Start()
    {
        Destroy(gameObject,destroyByTime);
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         EnemyHealth otherEnemy = other.GetComponent<EnemyHealth>();
         Boss boss = other.GetComponent<Boss>();
         Boss2 boss2 = other.GetComponent<Boss2>();
         FinalBoss final = other.GetComponent<FinalBoss>();

         if( final !=null)
         {
            final.TakeDamage(damage);
         }

         if(boss2 !=null)
         {
            boss2.TakeDamage(damage);
         }

         if(boss !=null)
         {
            boss.TakeDamage(damage);
         }
        if(otherEnemy !=null)
        {
            otherEnemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
