using UnityEngine;
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
    Sprite onWall;
    bool canJump = false;
    Transform fallingTwilight;

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
        onWall = Resources.Load("RoffeV2onWall", typeof(Sprite)) as Sprite;
        fallingTwilight = transform.FindChild("blackMatter (2)");
    }
	
	// Update is called once per frame
	void Update () {
        var boxCollider = GetComponent<BoxCollider2D>();
        var rigidBody = GetComponent<Rigidbody2D>();
        var jumpBar = transform.FindChild("jumpBar");
        barGrowing = (Input.GetKey("a") || Input.GetKey("d")) && canJump;
        if (barGrowing){
            if (jumpForce <= 100){
                jumpForce = jumpForce + Time.deltaTime * 200;
            }
                     
        }
        var handCodeBlock = 120.0f + jumpForce / 100.0f * 40.0f;
        leftHand.localEulerAngles = new Vector3(0,0,-handCodeBlock);
        rightHand.localEulerAngles = new Vector3(0,0,handCodeBlock);
        if ((Input.GetKeyUp("a") || Input.GetKeyUp("d")) && canJump) {
            var directionMultiplier = Input.GetKeyUp("a") ? -1 : 1;
            ukkoSkaalaus.localScale = new Vector3(directionMultiplier,1);
            var speed = jumpForce / 100 * 7;
            rigidBody.velocity = new Vector2(directionMultiplier * speed, speed);
            jumpForce = 0;
        }
        jumpBar.localScale = new Vector3(jumpForce / 100 * 0.8f, 0.007f);
    }

    void OnCollisionEnter2D(Collision2D otherObject) {
        var direction = otherObject.contacts[0].normal;
        var collisionType = Collision(direction);

        Debug.Log("OnCollisionEnter2D is being executed! Direction: " + direction + ". The collision type is: " + collisionType + " and the tag is: " + otherObject.gameObject.tag);

        if (collisionType == "side") {
            ukkoSpriteRenderer.sprite = onWall;
            midAir.enabled = false;
            canJump = true;
        } else if(collisionType == "top") {
            ukkoSpriteRenderer.sprite = regularSprite;
            midAir.enabled = false;
            canJump = true;
        } else if(collisionType == "bottom") {
            ukkoSkaalaus.localScale = new Vector3(1, 0.8f);
        }
    }

    void OnCollisionExit2D(Collision2D otherObject) {
        var direction = otherObject.contacts[0].normal;
        var collisionType = Collision(direction);


        if (collisionType == "side" || collisionType == "top") {
            midAir.enabled = true;
            canJump = false;
        } else {
            ukkoSkaalaus.localScale = new Vector3(1, 1);
        }
    }

    String Collision(Vector2 direction) {            
        return direction.x < -0.9 || direction.x > 0.9 ? "side" :
               direction.y > 0.9 ? "top" : "bottom";
    }

    void enemyHasHitPlayer(GameObject enemy) {
        Debug.Log("Roffe was hit by:" + enemy.tag);
        fallingTwilight.position = new Vector3(-23, 0, -10);
    }

}

//Console used with: Debug.Log(Value or thing to the console);

