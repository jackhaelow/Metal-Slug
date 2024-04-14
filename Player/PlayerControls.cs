using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
     private int bullets;
     private  float reloadTime = 1.6f;
     private int health;
     private int maxHealth;
     private int bombs;
     GameManager gameManager;
   private bool reloading;
   private float fireRate= 0.5f;
     private bool isGrounded;
   private float nextFire;
   private bool isFacingRight =true;
   private SpriteRenderer sprite;
    private Rigidbody2D rb;
   private float dirX;
    protected Animator anim;
    private bool tookDamage = false;

   
   public Transform attackPoint;
   public float attackRange = 0.5f;
   public LayerMask enemyLayers;
   
   
   public float damageTime = 1f;
   public AudioClip deathSfx;
   public AudioClip shootSfx;
   public AudioClip reloadSfx;
    public float jumpForce = 7f;
    public Rigidbody2D bomb;
    private bool isDead = false;
    public Transform bombSpawner;
    public Transform shotSpawner;
    public GameObject bullet;
   
     public float speed = 2f;
    public Joystick Joystick;
   
    
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();   
        gameManager = GameManager.gameManager;
        SetPlayerStatus();
        UpdateBombsUI();
        UpdateBulletsUI();
        health = maxHealth;
        UpdateHealthUI();
       UpdateCoinsUI();  
    }

  
    void Update()
    {
       Movements(); 
    }
    private void Movements()
    {
        dirX = Joystick.Horizontal;
        rb.velocity = new Vector2 (dirX * speed,rb.velocity.y);

        anim.SetBool("run", dirX !=0);

        if(dirX > 0 && !isFacingRight)
        {
            Flip();
            anim.SetBool("crouch",false);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }else if( dirX < 0 && isFacingRight)
        {
             anim.SetBool("crouch",false);
             rb.bodyType = RigidbodyType2D.Dynamic;
            Flip();
        }
    }
    protected void Flip()
    {
        isFacingRight = !isFacingRight;

      transform.Rotate(0f,180f,0f);
    }
    
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if(collision.gameObject.tag == "Ground")
      {
         isGrounded = true;
         anim.SetBool("jump",false);
      }
      if(collision.gameObject.CompareTag("Enemy") && !tookDamage)
      {
         StartCoroutine(TookDamage());
      }
      else if( collision.gameObject.CompareTag("Coin"))
      {
         Destroy(collision.gameObject);
         gameManager.coins +=1;
         UpdateCoinsUI();
      }
   }

   public void JumpButton()
   {
      if(isGrounded && !isDead)
      {
         rb.velocity = new Vector2(rb.velocity.x,jumpForce);
         isGrounded = false;
         anim.SetBool("jump",true);
      }
   }

   public void ShootButton()
   {
      if(Time.time > nextFire && isGrounded  && bullets > 0 && !reloading && !isDead && CanAttack()  )
      {
         nextFire = Time.time + fireRate;
         GameObject tempBullet = Instantiate(bullet,shotSpawner.position,shotSpawner.rotation);
          anim.SetTrigger("shoot");
          anim.SetTrigger("Crouch shoot");  
          bullets--;
         UpdateBulletsUI();
         SoundManager.instance.PlaySound(shootSfx);
          
      }
      
       
   }

   public void BombButton()
   {
       if(bombs >0 && isGrounded && !reloading && nextFire < Time.time && !isDead && CanAttack() )
       {
         nextFire = Time.time + fireRate;
              Rigidbody2D tempBomb = Instantiate(bomb,bombSpawner.position,bombSpawner.rotation);

      if(isFacingRight )
      {
         tempBomb.AddForce(new Vector2(4,6),ForceMode2D.Impulse);
      }
      else{
          tempBomb.AddForce(new Vector2(-4,6),ForceMode2D.Impulse);
      }
      anim.SetTrigger("bomb");
       }
       bombs--;
       UpdateBombsUI();
   }
  
   public void ReloadButton()
   {
      if(isGrounded && !isDead) 
      {
         StartCoroutine(Reload());
      }
   }

   IEnumerator Reload()
   {
      anim.SetTrigger("reload");
      reloading = true;
      rb.bodyType = RigidbodyType2D.Static;
      yield return new WaitForSeconds(reloadTime);
      SoundManager.instance.PlaySound(reloadSfx);
      reloading = false;
   
      bullets = gameManager.bullets;
      UpdateBulletsUI();
      rb.bodyType = RigidbodyType2D.Dynamic;
   }

   public void CrouchButton()
   {
      anim.SetBool("crouch",true);
      rb.bodyType = RigidbodyType2D.Static;
   } 

   public void StabButton()
   {
      if(isGrounded && !reloading && !isDead)
      {
         StartCoroutine(Stab());
      }
   }

   IEnumerator Stab()
   {
       anim.SetTrigger("stab");
    
       Collider2D[] hitEnemy= Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
       
       foreach(Collider2D enemy in hitEnemy)
       {
         enemy.GetComponent<EnemyHealth>().TakeDamage(2);
       }

        rb.bodyType = RigidbodyType2D.Static;
       yield return new WaitForSeconds(1f);
       rb.bodyType = RigidbodyType2D.Dynamic;
       
   }

   public void SetPlayerStatus()
   {
      fireRate = gameManager.fireRate;
      reloadTime = gameManager.reloadTime;
      bullets = gameManager.bullets;
      maxHealth = gameManager.health;
      bombs = gameManager.bombs;
   }
   void UpdateBulletsUI()
   {
      FindObjectOfType<UIManager>().UpdateBulletsUI(bullets);
   }
   void UpdateBombsUI()
   {
      FindObjectOfType<UIManager>().UpdateBombsUI(bombs);
      gameManager.bombs = bombs;
   }
   void UpdateHealthUI()
   {
      FindObjectOfType<UIManager>().UpdateHealthUI(health);
   }


   void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Enemy")&& !tookDamage)
      {
         StartCoroutine(TookDamage());
      }
   }
  

   IEnumerator TookDamage()
   {
      tookDamage = true;
      health--;
      UpdateHealthUI();
      if(health <= 0 )
      {
           rb.bodyType = RigidbodyType2D.Static;
          isDead = true;
         anim.SetTrigger("die");
         SoundManager.instance.PlaySound(deathSfx);
         Invoke("ReloadScene",2f);

         
      }
      else
      {
         Physics2D.IgnoreLayerCollision(6,9);
         for(float i = 0; i < damageTime; i+= 0.2f)
         {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
         }
          Physics2D.IgnoreLayerCollision(6,9,false);
          tookDamage = false;
      }
   }
   void UpdateCoinsUI()
   {
      FindObjectOfType<UIManager>().UpdateCoins();
   }

  public void SetHealthAndBombs(int life, int bomb)
  {
     health += life;
     if(health >= maxHealth)
     {
       health = maxHealth;
     }
     bombs +=bomb;
     UpdateBombsUI();
     UpdateHealthUI();
  }

   void ReloadScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
     public void UpdateWeapon(GameObject newWeapon)
   {
      bullet = newWeapon;
      

   }
   bool CanAttack()
   {
      return dirX == 0;
   }

   void OnDrawGizmosSelected()
   {
      if(attackPoint == null)
      return;
      Gizmos.DrawWireSphere(attackPoint.position,attackRange);
   }
}