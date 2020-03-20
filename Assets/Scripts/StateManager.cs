using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// * Simlple State manager to test for if the player has won
public class StateManager : MonoBehaviour
{

  Canvas gameOverScreen;
  bool gameEnded = false;

  private void Awake() {
    // * Find the canvas and store it in a variable
    gameOverScreen = FindObjectOfType<Canvas>();
    
    // * turn it off
    gameOverScreen.enabled = false;
  }

  public void GameOver () {

    if(!gameEnded)
    {
      // * Turn on the screen
      gameEnded = true;
      gameOverScreen.enabled = true;
    } 
  }

  public void Restart()
  {
    // * Onclick function for the button, use scenemanager to restart the scene
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void Exit()
  {
    Application.Quit();
  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if(gameOverScreen.enabled)
      {
        gameOverScreen.enabled = false;
      }
      else{
        gameOverScreen.enabled = true;
      }
      
    }
  }
}
