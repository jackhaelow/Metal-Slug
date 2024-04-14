using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniUfo : MonoBehaviour
{
    public bool isFlipped = false;
    public float speed;
    public float shootingRange;
    public GameObject bullet;
    public float fireRate =1f;
    private float nextFireTime;
    public Transform shotSpawner;
   private  Transform player;
    public float lineOfSite = 25f;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            
        }
        else if( distance  <= shootingRange && nextFireTime  <Time.time)
        {
            Instantiate(bullet,shotSpawner.position,shotSpawner.rotation);
          nextFireTime = Time.time + fireRate;
          
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
