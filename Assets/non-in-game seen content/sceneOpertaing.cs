using UnityEngine;
using System.Collections;

public class sceneOpertaing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape")) Application.Quit();
	}

    void enemyHasHitPlayer(GameObject foe) {
        Debug.Log("enemyHasHitPlayer is executed!");
        var enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject enemy in enemies) {
            var enemyAnimation = enemy.GetComponent<Animation>();
            enemyAnimation.enabled = false;
        }
    }

    //respawns = GameObject.FindGameObjectsWithTag("Respawn");
}
