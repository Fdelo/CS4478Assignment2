using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{

  Canvas gameOverScreen;
  bool gameEnded = false;

  private void Awake() {
      gameOverScreen = FindObjectOfType<Canvas>();
      // gameOverScreen.gameObject.SetActive(false);
      gameOverScreen.enabled = false;
  }

  public void GameOver () {

    if(!gameEnded)
    {
      gameEnded = true;
      // gameOverScreen.gameObject.SetActive(true);      
      gameOverScreen.enabled = true;
    } 
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
