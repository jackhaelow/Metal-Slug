using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int health = 10;
    public int damage = 1;
    public float fireRate = 0.5f;
    public float reloadTime = 1f;
    public int bullets = 10;
    public int coins;
    public int bombs =6;
    public int Upgrade = 20;
    public static GameManager gameManager;
    
    void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

   
    void Update()
    {
        
    }
}
