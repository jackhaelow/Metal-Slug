using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaTank : MonoBehaviour
{
    public bool isFlipped = false;
    public float speed;
    public float shootingRange;
    public GameObject bullet;
    public float fireRate =1f;
    private float nextFireTime;
    public Transform shotSpawner;
    public Transform player;
    public float lineOfSite;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    
 void Update()
    {
       
      Movement();  
}

    void Movement()
    {

        LookAtPlayer();
        float distance = Vector2.Distance(player.position,transform.position);

        if(distance < lineOfSite && distance > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,player.transform.position, speed * Time.deltaTime);
            anim.SetBool("run",true);
        }
        else if( distance  <= shootingRange && nextFireTime  <Time.time)
        {
           anim.SetTrigger("shoot"); 
          Instantiate(bullet,shotSpawner.position,shotSpawner.rotation);
          nextFireTime = Time.time + fireRate;
          anim.SetBool("run",false);
          
        }
        else
        {
            anim.SetBool("run",false);
            anim.ResetTrigger("shoot");
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
