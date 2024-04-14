using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   public float destroybyTime = 0.5f;
   
   public int damage = 5;
    void Start()
    {
      Destroy(gameObject,destroybyTime);
     
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
