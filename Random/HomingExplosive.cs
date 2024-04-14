using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingExplosive : MonoBehaviour
{
    public int damage = 5;

     private void OnTriggerEnter2D(Collider2D other)
    {
         Boss boss = other.GetComponent<Boss>();
         EnemyHealth otherEnemy = other.GetComponent<EnemyHealth>();
         Boss2 boss2 = other.GetComponent<Boss2>();
         FinalBoss final = other.GetComponent<FinalBoss>();
          
          if( final !=null)
         {
            final.TakeDamage(damage);
         }

         if(boss !=null)
         {
            boss.TakeDamage(damage);
         }

        if(boss2 !=null)
         {
            boss2.TakeDamage(damage);
         }
        
        if(otherEnemy !=null)
        {
            otherEnemy.TakeDamage(damage);
        }

       Destroy(gameObject,1f);
    }
}
