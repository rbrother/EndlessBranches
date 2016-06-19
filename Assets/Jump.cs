using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var boxCollider = GetComponent<BoxCollider2D>();
        var touching = boxCollider.IsTouchingLayers();
        var rigidBody = GetComponent<Rigidbody2D>();
        if (Input.GetKeyUp("a") && touching) {
            rigidBody.velocity = new Vector2(-3, 3);
        }
        else if (Input.GetKeyUp("d") && touching) {
            rigidBody.velocity = new Vector2(3, 3);
            
        }
    }
}

