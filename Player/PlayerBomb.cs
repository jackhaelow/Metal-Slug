using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
   public GameObject explosion;
      public AudioClip explodeSfx;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion,transform.position ,transform.rotation);
        Destroy(gameObject);
         SoundManager.instance.PlaySound(explodeSfx);
    }
}
