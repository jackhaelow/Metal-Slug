using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
   public Rigidbody2D bullet;
   public AudioClip Sfx;
   public GameObject missionComplete;
   public GameObject sound;
   public int health;
   public Transform[] shotSpawners;
   private bool isDead = false;
   public float minYForce,maxYForce;
   public float fireRateMin,fireRateMax;
   public float minEnemyTime,maxEnemyTime;
   private SpriteRenderer sprite;
   public GameObject enemy;
   public GameObject lazer;
   public Transform laserSpawn;
   public float minLazerTime,MaxLazerTime;
   public Transform enemySpawn;
   public GameObject player;
    void Start()
    {
       
        sprite = GetComponent<SpriteRenderer>();
       
         
    }


    void Update()
    {
        
    }
    void FireLazer()
    {
        if(!isDead)
        {
            Instantiate(lazer,laserSpawn.position,laserSpawn.rotation);
             Invoke("FireLazer",Random.Range(minLazerTime,maxEnemyTime));
        }
    }
    void InstantiateEnemies()
    {
       if(!isDead)
       {
         Instantiate(enemy,enemySpawn.position,enemySpawn.rotation);
         Invoke("InstantiateEnemies",Random.Range(minEnemyTime,maxEnemyTime));
       }
    }
    public void ActivateBoss()
    {
        GetComponent<PolygonCollider2D>().enabled = true;
        Invoke("Fire",Random.Range(fireRateMin,fireRateMax));
         Invoke("InstantiateEnemies",Random.Range(minEnemyTime,maxEnemyTime));
        Invoke("FireLazer",Random.Range(minLazerTime,maxEnemyTime));
    }
    void Fire()
    {
        if(!isDead)
        {
            Rigidbody2D tempBullet = Instantiate(bullet,shotSpawners[Random.Range(0,shotSpawners.Length)].position,Quaternion.identity);
            tempBullet.AddForce(new Vector2(0,Random.Range(minYForce,maxYForce)),ForceMode2D.Impulse);
            Invoke("Fire",Random.Range(fireRateMin,fireRateMax));
        }
    }
       public void TakeDamage(int amount)
   {
     health -= amount;

     if(health == 0)
     {
        enemy.SetActive(false);
      
        isDead = true;
      
       Invoke("LoadScene",7f);
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
