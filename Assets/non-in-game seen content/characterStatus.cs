using System;
using UnityEngine;
using System.Collections;

public class characterStatus : MonoBehaviour {

    Transform fallingTwilight;
    RectTransform auraBarRect;
    GameObject auraBar;
    public static bool inQTE;
    float shield;
    GameObject parentOfQTE;
    System.Random random;
    string QTEtext;
    GameObject pressable;
    TextMesh pressableOfQTE;

    // Use this for initialization
    void Start () {
        fallingTwilight = transform.FindChild("blackMatter (2)");
        auraBar = GameObject.Find("shield");
        auraBarRect = auraBar.GetComponent<RectTransform>();
        inQTE = false;
        shield = 1;
        parentOfQTE = transform.FindChild("firstQTE").gameObject;
        parentOfQTE.SetActive(false);
        random = new System.Random();
        pressable = parentOfQTE.transform.FindChild("QTE Pressable").gameObject;
        pressableOfQTE = pressable.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update() {
        //Input.GetKeyUp("a") || Input.GetKeyUp("d")) && canJump
        if (inQTE) {
            var keysDown = 0;
            if (Input.GetKey("a")) keysDown++;
            if (Input.GetKey("w")) keysDown++;
            if (Input.GetKey("d")) keysDown++;
            if (Input.GetKey("s")) keysDown++;
            if (shield >= 0) {
                auraBarRect.localScale = new Vector3(shield, 1, 1);
                shield = shield - Time.deltaTime * 0.1f;
            }
            if (keysDown == 1 && Input.GetKey(QTEtext)) {
                    Debug.Log("No longer under attack!");
            }
        }
    }

    void enemyHasHitPlayer(GameObject enemy) {
        fallingTwilight.localPosition = new Vector3(-13.7f, 5.1f, -8);
        inQTE = true;
        parentOfQTE.SetActive(true);
        var n = random.Next(1, 4);
        if(n == 1) {
            QTEtext = "w";
        }else if(n == 2) {
            QTEtext = "d";
        }else if(n == 3) {
            QTEtext = "s";
        }else {
            QTEtext = "a";
        }
        pressableOfQTE.text = QTEtext;
    }
}
