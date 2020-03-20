using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardHolder : MonoBehaviour
{

  StateManager stateManager;

  List<Transform> childTransforms;

  // * predefine the grid that the cards sit on
  // * these get shuffled at the start of the scene
  private Vector2[] tforms =
  {
    new Vector2(-2, 1),
    new Vector2(2, 1),
    new Vector2(6, 1),
    new Vector2(6, -2),
    new Vector2(2, -2),
    new Vector2(-2, -2),
    new Vector2(-6, 1),
    new Vector2(-6, -2)
  };

  public List<string> gameState; // * Track which cards are currently flipped
  public Dictionary<string, bool> matches; // * Track the matches the player has

  void Start()
  {
    // * Initialize variables
    stateManager = FindObjectOfType<StateManager>();
    gameState = new List<string>();
    childTransforms = new List<Transform>();
    matches = new Dictionary<string, bool>();
    matches.Add("cow", false);
    matches.Add("cat", false);
    matches.Add("sheep", false);
    matches.Add("mouse", false);

    int i = 0;
    // * initialze the array containing references to all the child tranforms
    foreach (Transform tr in transform)
    {
      childTransforms.Add(tr);
    }
    i = 0;
    System.Random rnd = new System.Random();
    // * randomize the order of the transforms identified above
    Vector2[] shuffled_tforms = tforms.OrderBy(x => rnd.Next()).ToArray();
    foreach (Transform t in childTransforms)
    {
      t.position = shuffled_tforms[i];
      i++;
    }
  }

  // * Check the game state list
  public void checkGameState()
  {
    // * If the two selected cards are the same
    if (gameState[0] == gameState[1])
    {
      // * update the matches dictonary so these cards stay flipped
      matches[gameState[0]] = true;

      // * clear the gamestate
      gameState.Clear();

      // * if all matches are found end the game
      if (!matches.ContainsValue(false))
      {
        stateManager.GameOver();
      }
    }
    // * Two selected cards are not the same    
    else
    {
      // * Add 1 second of waiting so the player can see the cards
      System.Threading.Thread.Sleep(1000);
      foreach (Transform tr in childTransforms)
      {
        // * flip the cards over that are in the game state
        if (tr.name.Substring(0, tr.name.Length - 1).ToLower() == gameState[0] || tr.name.Substring(0, tr.name.Length - 1).ToLower() == gameState[1])
        {
          tr.GetComponent<Card>().spriteSwitch();
        }
      }
      // * remove the cards from the game state
      gameState.Clear();
    }
  }
}
