 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int health;
    public int bombs;
     public AudioClip pickUp;
     private void OnTriggerEnter2D(Collider2D coll)
     {
        PlayerControls player = coll.GetComponent<PlayerControls>();

        if(player !=null)
        {
            player.SetHealthAndBombs(health,bombs);
            Destroy(gameObject);
              SoundManager.instance.PlaySound(pickUp);
        }
     }
}
