using UnityEngine;
using System.Collections;

public class whiteBoxCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log("Collider triggered! The GameObject's " + coll.gameObject.tag);
        var whiteBox = transform.FindChild("WhiteBox");
        var colorProperties = GetComponent<SpriteRenderer>();
        if (coll.gameObject.tag == "Player") {
            colorProperties.color = new Color(1, 0, 0);
        }
    }
}
