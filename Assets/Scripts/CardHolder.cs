using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardHolder : MonoBehaviour
{

    
    List<Transform> childTransforms;

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

    public List<string> gameState;
    public Dictionary<string, bool> matches;

    // Start is called before the first frame update
    void Start()
    {      
      gameState = new List<string>();
      childTransforms = new List<Transform>();
      matches = new Dictionary<string, bool>();
      matches.Add("cow", false);
      matches.Add("cat", false);
      matches.Add("sheep", false);
      matches.Add("mouse", false);
      int i = 0;
     
      foreach (Transform tr in transform){
        childTransforms.Add(tr);
      }
      i = 0;
      System.Random rnd = new System.Random();
      Vector2[] shuffled_tforms = tforms.OrderBy(x => rnd.Next()).ToArray();
      foreach (Transform t in childTransforms)
      {
        t.position = shuffled_tforms[i];          
        i++;
      }
    }

         
    private void Update() {
      if(gameState.Count > 1)
      {
        if(gameState[0] == gameState[1])
        {
          matches[gameState[0]] = true;
          gameState.Clear();
        }

        else
        {
          foreach(Transform tr in childTransforms)
          {
            if(tr.name.Substring(0, tr.name.Length - 1).ToLower() == gameState[0] || tr.name.Substring(0, tr.name.Length - 1).ToLower() == gameState[1])
            {
              tr.GetComponent<SpriteRenderer>().sprite = tr.gameObject.GetComponent<Card>().blank_art;
            }            
          }
          gameState.Clear();
        }
      }
    }
}
