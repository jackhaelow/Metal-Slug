using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
   private bool isDead = false;
   public AudioClip Sfx;
   public GameObject missionComplete;
      public GameObject sound;
   public GameObject player;
   public int health;
   public GameObject enemy;
   public Transform enemySpawner;
   public float minenemyTime,maxEnemyTime;
   public Rigidbody2D cannon;
   public float minCannonTime,maxCannonTime;
   public Transform cannonSpawner;
   public float cannonYForce,cannonXForce;
   public GameObject missle;
   public Transform[] shotSpawners;
   public float minMissleTime,maxMissleTime;
   public GameObject flameShot;
   public Transform flameSpawner;
   public float minFireTime,maxFireTime;
     private SpriteRenderer sprite;
   void Start()
   {
      ActivateBoss();
        sprite = GetComponent<SpriteRenderer>();
   }

   void FireMissle()
   {
       if(!isDead)
       {
          Instantiate(missle,shotSpawners[Random.Range(0,shotSpawners.Length)].position,Quaternion.identity);
          Invoke("FireMissle",Random.Range(minMissleTime,maxMissleTime));
       }
   }

   void FireCannon()
   {
      if(!isDead)
      {
          Rigidbody2D tempCannon = Instantiate(cannon,cannonSpawner.position,cannonSpawner.rotation);

          tempCannon.AddForce( new Vector2(cannonXForce,cannonYForce),ForceMode2D.Impulse);

          Invoke("FireCannon",Random.Range(minCannonTime,maxCannonTime));
      }
   }

   void EnemySpawn()
   {
       if(!isDead)
       {
         Instantiate(enemy,enemySpawner.position,enemySpawner.rotation);
          Invoke("EnemySpawn",Random.Range(minenemyTime,maxEnemyTime));
       }
   }

   void FlameShot()
   {
       if(!isDead)
       {
          Instantiate(flameShot,flameSpawner.position,flameSpawner.rotation);
          Invoke("FlameShot",Random.Range(minFireTime,maxFireTime));
       }
   }

   void ActivateBoss()
   {
        Invoke("FireMissle",Random.Range(minMissleTime,maxMissleTime));
       Invoke("FireCannon",Random.Range(minCannonTime,maxCannonTime));
       Invoke("FlameShot",Random.Range(minFireTime,maxFireTime));
        Invoke("EnemySpawn",Random.Range(minenemyTime,maxEnemyTime));
   }
      private IEnumerator TookDamage()
   {
      sprite.color =  Color.red;
      yield return new WaitForSeconds(0.1f);
      sprite.color =  Color.white;
   }
       public void TakeDamage(int amount)
   {
     health -= amount;

     if(health == 0)
     {
        enemy.SetActive(false);
      
        isDead = true;
      
       Invoke("NextScene",7f);
      player.GetComponent<Animator>().SetBool("Celebrate",true);
      player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
      player.GetComponent<PlayerControls>().enabled =false;
      player.GetComponent<PolygonCollider2D>().enabled = false;
        missionComplete.SetActive(true);
        SoundManager.instance.PlaySound(Sfx);
      sound.SetActive(false);

       
     }
     else
     {
         StartCoroutine(TookDamage());
     }
   }
   void NextScene()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
}
