using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{
   public GameObject weaponToGive;
   public AudioClip pickUp;
 

   void OnTriggerEnter2D(Collider2D other)
   {
      if(other.gameObject.tag == "Player")
      {
         SoundManager.instance.PlaySound(pickUp);
        other.gameObject.GetComponent<PlayerControls>().UpdateWeapon(weaponToGive);
         Destroy(gameObject);
      }
     
   }
}
