using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    bool gsc = false;
    SpriteRenderer sr;
    SpriteRenderer sr_blank;
    BoxCollider2D bc2d; 
    CardHolder parentScript;
    public string card_name;
    

    private void Awake() {
      sr = GetComponent<SpriteRenderer>();

      parentScript = transform.parent.GetComponent<CardHolder>();
    }
    // Start is called before the first frame update
    void Start()
    {
      sr_blank = transform.GetChild(0).GetComponent<SpriteRenderer>();      
      bc2d = gameObject.AddComponent<BoxCollider2D>();        
    }

    private void OnMouseDown() {
      if (sr_blank.enabled)
      {
        sr_blank.enabled = false;
        
        parentScript.gameState.Add(card_name);
      }

    }
    private void FixedUpdate() {
      if (parentScript.gameState.Count > 1){
        parentScript.checkGameState();
      }
      
    }
    public void spriteSwitch() {
      sr_blank.enabled = true;
    }

}
