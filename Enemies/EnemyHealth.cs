using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

public GameObject coin;
public GameObject deathAnimation;
private SpriteRenderer sprite;
    void Start()
    {
        health = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

   public void TakeDamage(int amount)
   {
     health -= amount;

     if(health <= 0)
     {
        Instantiate(coin,transform.position,transform.rotation);
        Instantiate(deathAnimation,transform.position,transform.rotation);

        gameObject.SetActive(false);
     }
     else
     {
         StartCoroutine(TookDamage());
     }
   }

   private IEnumerator TookDamage()
   {
      sprite.color =  Color.red;
      yield return new WaitForSeconds(0.1f);
      sprite.color =  Color.white;
   }
}
