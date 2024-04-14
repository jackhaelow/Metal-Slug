using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject player;
    private Animator anim;
    public AudioClip ohkSfx;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
  
   private void OnTriggerEnter2D(Collider2D collider)
   {
      if(collider.gameObject.tag == "Player")
      {
        player.SetActive(false);
        SoundManager.instance.PlaySound(ohkSfx);
        anim.SetTrigger("checkpoint");
        Invoke("NextLevel",2f);
      }
   }

      void NextLevel()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }
}
