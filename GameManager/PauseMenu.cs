using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject sound;
  public void Pause()
  {
    pauseMenu.SetActive(true);
    sound.SetActive(false);
    Time.timeScale = 0;
    
  }

  public void Home()
  {
    SceneManager.LoadScene(0);
    Time.timeScale = 1;
  }

  public void Resume()
  {
     pauseMenu.SetActive(false);
      sound.SetActive(true);
      Time.timeScale = 1;
  }
  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     Time.timeScale = 1;
  }
}
