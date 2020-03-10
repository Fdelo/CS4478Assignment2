using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardHolder : MonoBehaviour
{

    
    Transform[] childTransforms;

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

    // Start is called before the first frame update
    void Start()
    {      
      int i = 0;
      childTransforms = new Transform[8];
      foreach (Transform tr in transform){
        childTransforms[i] = tr;
        i++;
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

    
}
