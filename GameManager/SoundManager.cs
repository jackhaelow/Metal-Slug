using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource source;
    public static SoundManager instance{get; private set;}
   
    void Awake()
    {
        instance = this;
       source = GetComponent<AudioSource>(); 
    }

    
   public void PlaySound(AudioClip _sound)
   {
       source.PlayOneShot(_sound);
   }
}
