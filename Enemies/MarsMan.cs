using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsMan : MonoBehaviour
{
   
     public float speed = 2f;
    public float lineOfSite;
    public float shootingRange;
    private float nextFireTime;
    public float fireRate = 1f;
    private Transform player;
    public GameObject bullet;
    public Transform shotSpawner;
    private Animator anim;
      public bool isFlipped = false;
     void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

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
            anim.SetBool("run",true);
        }
        else if(distance <= shootingRange && nextFireTime < Time.time )
        {
            nextFireTime = Time.time + fireRate;
            anim.SetBool("run",false);
             Instantiate(bullet,shotSpawner.position,shotSpawner.rotation);

            

            anim.SetTrigger("attack");
        }
        else
        {
            anim.SetBool("run",false);
            anim.ResetTrigger("attack");
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
