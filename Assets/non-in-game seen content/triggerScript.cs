using UnityEngine;
using System.Collections;

public class triggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("The TRIGGERED game objet's tag is: " + other.gameObject.tag);
        other.gameObject.SendMessage("enemyHasHitPlayer",gameObject);
    }

    //the code block above can be used in variety of things

}
