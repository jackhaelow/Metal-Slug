using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rebel3 : MonoBehaviour
{
     public float speed = 2f;
    public float lineOfSite;
    public float shootingRange;
    private float nextFireTime;
    public float fireRate = 1f;
    public Transform player;
    public GameObject bullet;
    public Transform shotSpawner;
    private Animator anim;
      public bool isFlipped = false;
   
    void Start()
    {
        anim = GetComponent<Animator>();


    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        LookAtPlayer();
        float distance = Vector2.Distance(player.position,transform.position);

        if(distance < lineOfSite && distance > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed * Time.deltaTime);
            anim.SetBool("Walk",true);
        }
        else if(distance <= shootingRange && nextFireTime < Time.time )
        {
            anim.SetBool("Walk",false);
            
            anim.SetTrigger("Shoot");
            
             Instantiate(bullet,shotSpawner.position,shotSpawner.rotation);
            nextFireTime = Time.time + fireRate;
           

            
        }
        else
        {
            anim.SetBool("Walk",false);
            anim.ResetTrigger("Shoot");
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
