using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject player;
    public AudioClip ohkSfx;
  
   private void OnTriggerEnter2D(Collider2D collider)
   {
      if(collider.gameObject.tag == "Player")
      {
        player.SetActive(false);
        SoundManager.instance.PlaySound(ohkSfx);
        Invoke("ReloadScene",2f);
      }
   }

      void ReloadScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }
}
