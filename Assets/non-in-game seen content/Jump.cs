﻿using UnityEngine;
using System;
using System.Collections;

public class Jump : MonoBehaviour {

    float jumpForce = 0;
    bool barGrowing = false;
    Sprite loadingSprite;
    Transform ukkoSkaalaus;
    SpriteRenderer ukkoSpriteRenderer;
    Sprite firstFlyingSprite;
    Sprite regularSprite;
    Animator midAir;
    Transform leftHand;
    Transform rightHand;
   
    // Use this for initialization
    void Start () {
	    loadingSprite = Resources.Load("RoffeV2withNoArms", typeof(Sprite)) as Sprite;
        firstFlyingSprite = Resources.Load("RoffeHavingHisLeftFootOut", typeof(Sprite)) as Sprite;
        Debug.Log(loadingSprite);
        ukkoSkaalaus = transform.FindChild("ukko");
        ukkoSpriteRenderer = ukkoSkaalaus.GetComponent<SpriteRenderer>();
        regularSprite = ukkoSpriteRenderer.sprite;
        midAir = ukkoSkaalaus.GetComponent<Animator>();
        midAir.enabled = false;
        leftHand = ukkoSkaalaus.FindChild("Roffe'sLeftHand");
        rightHand = ukkoSkaalaus.FindChild("Roffe'sRightHand");
    }
	
	// Update is called once per frame
	void Update () {
        var boxCollider = GetComponent<BoxCollider2D>();
        var touching = boxCollider.IsTouchingLayers();
        var rigidBody = GetComponent<Rigidbody2D>();
        var jumpBar = transform.FindChild("jumpBar");
        barGrowing = (Input.GetKey("a") || Input.GetKey("d")) && touching;
        if (barGrowing){
            if (jumpForce == 0) jumpForce = 20;
            if (jumpForce <= 100){
            jumpForce = jumpForce + Time.deltaTime * 200;
            }
                     
        }
        var handCodeBlock = 120 + jumpForce / 100 * 40;
        leftHand.localEulerAngles = new Vector3(0,0,handCodeBlock);
        rightHand.localEulerAngles = new Vector3(0,0, -handCodeBlock);
        if ((Input.GetKeyUp("a") || Input.GetKeyUp("d")) && touching) {
            var directionMultiplier = Input.GetKeyUp("a") ? -1 : 1;
            ukkoSkaalaus.localScale = new Vector3(directionMultiplier, 1);
            var speed = jumpForce / 100 * 7;
            rigidBody.velocity = new Vector2(directionMultiplier * speed, speed);
            jumpForce = 0;
        }
        jumpBar.localScale = new Vector3(jumpForce / 100 * 45, 1);
        if (!touching) {
            midAir.enabled = true;
        }else if (barGrowing) {
            ukkoSpriteRenderer.sprite = loadingSprite;
        }else {
            midAir.enabled = false;
            ukkoSpriteRenderer.sprite = regularSprite;
        }
    }
}

//Console used with: Debug.Log(Value or thing to the console);
