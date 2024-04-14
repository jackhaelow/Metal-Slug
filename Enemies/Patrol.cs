using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Enemy
{
    public GameObject bullet;
    public float fireRate;
    public Transform shotSpawner;
    private float nextFire;

    public Animator animator;

    void Start()
    {
        
    }

   
   protected override  void Update()
    {
        base.Update();
        if(targetDistance < 0)
        {
            if(!facingRight)
            {
                Flip();
            }
        }
        else
        {
            if(facingRight)
            {
                Flip();
            }
        }
        if(Mathf.Abs(targetDistance) < attackDistance && Time.time > nextFire)
        {
            animator.SetTrigger("Shooting");
            nextFire = Time.time + fireRate;
        }
    }

    public void Shooting()
    {
        GameObject tempBullet = Instantiate(bullet,shotSpawner.position,shotSpawner.rotation);
        if(!facingRight)
        {
            tempBullet.transform.eulerAngles = new Vector3(0,0,180);
        }
    }
}
