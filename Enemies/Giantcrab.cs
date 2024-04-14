using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giantcrab : MonoBehaviour
{
    public float speed =2f;
    public bool isFlipped = false;
    public float targetDistance;
    public float attackDistance;
    private float nextAttack;
    public float attackRate =1f;
   

    public Transform player;

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movements();
    }

    void Movements()
    {
       float distance = Vector2.Distance(player.position,transform.position);
      LookAtPlayer();
        if(distance < targetDistance && distance > attackDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed * Time.deltaTime);
            anim.SetBool("Walk",true);
        }
        else if(distance <= attackDistance && nextAttack < Time.time )
        {
            nextAttack = Time.time + attackRate;
            
            anim.SetTrigger("Attack");
            anim.SetBool("Walk",false);
        }
        else
        {
            anim.SetBool("Walk",false);
            anim.ResetTrigger("Attack");
        }
        
    }
     private void LookAtPlayer()
 { 
      Vector3 flipped = transform.localScale;
      flipped.z *= -1f;

      if(transform.position.x > player.position.x && isFlipped)
      {
         transform.localScale  = flipped;
         transform.Rotate(0f,180f,0f);
         isFlipped = false;
      }
      else if(transform.position.x < player.position.x && !isFlipped)
      {
         transform.localScale  = flipped;
         transform.Rotate(0f,180f,0f);
         isFlipped = true;
      }
 }

}
