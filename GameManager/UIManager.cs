using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text bulletText;
    public Text healthText;
    public Slider healthBar;
    public Text coinsText;
    public Text bombsText;
    void Start()
    {
        UpdateCoins();
        UpdateHealthBar();
    }

    
   public void UpdateBulletsUI(int bullets)
   {
      bulletText.text = bullets.ToString();
   }
   public void UpdateHealthUI(int health)
   {
     healthText.text = health.ToString();
     healthBar.value = health;
   }
   public void UpdateCoins()
   {
     coinsText.text = GameManager.gameManager.coins.ToString();
   }
   public void UpdateBombsUI(int bombs)
   {
     bombsText.text = bombs.ToString();
   }
    public void UpdateHealthBar()
    {
        healthBar.maxValue = GameManager.gameManager.health;
    }
}
