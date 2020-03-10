﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    SpriteRenderer sr;
    BoxCollider2D bc2d; 
    public string card_name;
    public Sprite blank_art;
    public Sprite animal_art;

    private void Awake() {
      sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = blank_art;
        bc2d = gameObject.AddComponent<BoxCollider2D>();        
    }

    private void OnMouseDown() {
      if (sr.sprite.name == "mem1")
      {
        sr.sprite = animal_art;
      }

      else
      {
        sr.sprite = blank_art;
      }
    }
}