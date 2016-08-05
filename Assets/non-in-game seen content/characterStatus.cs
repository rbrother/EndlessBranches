using UnityEngine;
using System.Collections;

public class characterStatus : MonoBehaviour {

    Transform fallingTwilight;
    RectTransform auraBarRect;
    GameObject auraBar;
    public static bool inQTE;
    float shield;

    // Use this for initialization
    void Start () {
        fallingTwilight = transform.FindChild("blackMatter (2)");
        auraBar = GameObject.Find("shield");
        auraBarRect = auraBar.GetComponent<RectTransform>();
        inQTE = false;
        shield = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (inQTE) {            
            if(shield >= 0) {
                auraBarRect.localScale = new Vector3(shield, 1, 1);
                shield = shield - Time.deltaTime * 0.1f;
            }            
        }
    }

    void enemyHasHitPlayer(GameObject enemy) {
        fallingTwilight.localPosition = new Vector3(-13.7f, 5.1f, -8);
        inQTE = true;
    }
}
