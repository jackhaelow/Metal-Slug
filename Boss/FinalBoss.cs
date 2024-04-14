using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
   public int health;
    private SpriteRenderer sprite;
    public GameObject Player;
    public AudioClip Sfx;
   public GameObject missionComplete;
      public GameObject sound;
      

   public Transform player;
   private bool isDead = false;
   public GameObject blast;
   public Transform blastSpawner;
   public float minBlastTime,maxBlastTime;
   private Animator anim;

   public GameObject lazer;
   public Transform lazerSpawner;
   public float minLazerTime,maxLazerTime;

   public GameObject ufo;
   public Transform ufoSpawner;
   public float minUfoTime,maxUfoTime;

   public GameObject alien;
   public Transform alienSpawner;
   public float minAlienTime,maxAlienTime;

   public GameObject grave;
   public Transform[] graveSpawners;
   public float minGraveTime,maxGraveTime;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
       Activate();
    }
    void Blast()
    {
         if(!isDead)
         {
            anim.SetTrigger("attack");
            Instantiate(blast,blastSpawner.position,blastSpawner.rotation); 
            Invoke("Blast",Random.Range(minBlastTime,maxBlastTime));
         }
    }
    void Lazer()
    {
        if(!isDead)
        {
            Instantiate(lazer,lazerSpawner.position,lazerSpawner.rotation);
            Invoke("Lazer",Random.Range(minLazerTime,maxLazerTime));
        }
    }
    void Activate()
    {
        Invoke("Blast",Random.Range(minBlastTime,maxBlastTime));
       Invoke("Lazer",Random.Range(minLazerTime,maxLazerTime));
        Invoke("UfoSpawn",Random.Range(minUfoTime,maxUfoTime));
        Invoke("AlienSpawn",Random.Range(minAlienTime,maxAlienTime)); 
         Invoke("GraveSpawn",Random.Range(minGraveTime,maxGraveTime));
    }
    void UfoSpawn()
    {
        if(!isDead)
        {
    
            Instantiate(ufo,ufoSpawner.position,ufoSpawner.rotation);
            Invoke("UfoSpawn",Random.Range(minUfoTime,maxUfoTime));
        }
    }
    void AlienSpawn()
    {
        if(!isDead)
        {
            Instantiate(alien,alienSpawner.position,alienSpawner.rotation);
            Invoke("AlienSpawn",Random.Range(minAlienTime,maxAlienTime));
        }
    }

    void GraveSpawn()
    {
        if(!isDead)
        {
            Instantiate(grave,graveSpawners[Random.Range(0,graveSpawners.Length)].position,Quaternion.identity);
            Invoke("GraveSpawn",Random.Range(minGraveTime,maxGraveTime));
        }
    }
         public void TakeDamage(int amount)
   {
     health -= amount;

     if(health == 0)
     {
      
        isDead = true;
      anim.SetTrigger("die");
       Invoke("LoadScene",7f);
      Player.GetComponent<Animator>().SetBool("Celebrate",true);
      Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
      Player.GetComponent<PlayerControls>().enabled =false;
      Player.GetComponent<PolygonCollider2D>().enabled = false;
      missionComplete.SetActive(true);
        SoundManager.instance.PlaySound(Sfx);
      sound.SetActive(false);

       
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
   void LoadScene()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
}
