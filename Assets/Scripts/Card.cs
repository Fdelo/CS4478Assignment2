using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    
    SpriteRenderer sr;
    SpriteRenderer sr_blank;
    BoxCollider2D bc2d; 
    CardHolder parentScript;
    public string card_name;
    
    // * init variables
    private void Awake() {
      sr = GetComponent<SpriteRenderer>();
      sr_blank = transform.GetChild(0).GetComponent<SpriteRenderer>(); // * refence to the spriterenderer of the child object
      parentScript = transform.parent.GetComponent<CardHolder>();
    }

    void Start()
    {
      // *  Add a collider so this object can process mouse clicks
      bc2d = gameObject.AddComponent<BoxCollider2D>();      
    }

    private void OnMouseDown() {
      // * use the EventSystem variable to see if the Menu is up and prevents clicks through it
      if (sr_blank.enabled && !EventSystem.current.IsPointerOverGameObject())
      {
        // * disable the blank card sprite so the sprite with the card shows up
        sr_blank.enabled = false;        
        // * add the card type to the game state
        parentScript.gameState.Add(card_name);
      }

    }

    // * need to run this in fixed update so this logic fires before mouseclick logic
    // * the effect of this is that the sprite will change and then this logic will get called on the following frame
    // * so the player can see both cards flipped over
    private void FixedUpdate() {
      if (parentScript.gameState.Count > 1){
        parentScript.checkGameState();
      }
      
    }

    // * switch the sprite back
    public void spriteSwitch() {
      sr_blank.enabled = true;
    }

}
