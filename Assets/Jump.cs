using UnityEngine;
using System;
using System.Collections;

public class Jump : MonoBehaviour {

    float jumpForce = 0;
    bool barGrowing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var boxCollider = GetComponent<BoxCollider2D>();
        var touching = boxCollider.IsTouchingLayers();
        var rigidBody = GetComponent<Rigidbody2D>();
        var jumpBar = transform.FindChild("jumpBar");
        barGrowing = (Input.GetKey("a") || Input.GetKey("d")) && touching;

        if (barGrowing){
            if (jumpForce <= 100){
            jumpForce = jumpForce + Time.deltaTime * 200;
            }
                     
        }

        if(Input.GetKeyUp("a") || Input.GetKeyUp("d")) {
            var directionMultiplier = Input.GetKeyUp("a") ? -1 : 1;
            var ukkoSkaalaus = transform.FindChild("ukko");
            ukkoSkaalaus.localScale = new Vector3(directionMultiplier, 1);
            var speed = jumpForce / 100 * 7;
            rigidBody.velocity = new Vector2(directionMultiplier * speed, speed);
            jumpForce = 0;
        }
        jumpBar.localScale = new Vector3(jumpForce / 100 * 45, 1);
    }
}

//Console used with: Debug.Log(Value or thing to the console);

