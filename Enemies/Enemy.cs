using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
   public int health;
   public float speed;
   public float attackDistance;

   protected Animator anim;
   protected bool facingRight = true;
   public Transform target;
   protected float targetDistance;
   protected Rigidbody2D rb2d;
   private SpriteRenderer sprite;
    void Start()
    {
        anim = GetComponent<Animator>();
       
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

   
   protected virtual void Update()
    {
        targetDistance = transform.position.x - target.position.x;
    }

     protected void Flip()
    {
        facingRight = !facingRight;

      transform.Rotate(0f,180f,0f);
    }

  
}
