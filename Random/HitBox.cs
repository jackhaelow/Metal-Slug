using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
   public int damage = 1;
  

    private void OnTriggerEnter2D(Collider2D other)
    {
         EnemyHealth otherEnemy = other.GetComponent<EnemyHealth>();
        if(otherEnemy !=null)
        {
            otherEnemy.TakeDamage(damage);
          
        }

        
    }
}
