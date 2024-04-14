using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
  public bool isFlipped = false;
  public float speed = 10f;
  public float lineOfSite;
  public float shootingRange;
  public GameObject spit;
  public Transform spitSpawner;
  private Transform player;
  public float spitRate =1f;
  private float nextSpitTime;
  private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerControls>().transform;
    }

    
    void Update()
    {
        Movements();
    }

    void Movements()
    {
         LookAtPlayer();
        float distance = Vector2.Distance(player.position,transform.position);

        if(distance < lineOfSite && distance > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed * Time.deltaTime);
            anim.SetBool("walk",true);
        }
        else if (distance <= shootingRange && nextSpitTime < Time.time)
        {
            nextSpitTime = Time.time + spitRate;
            Instantiate(spit,spitSpawner.position,spitSpawner.rotation);
            anim.SetTrigger("spit");
        }
        else 
        {
            anim.SetBool("walk",false);
            anim.ResetTrigger("spit");
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
