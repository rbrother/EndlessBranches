using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class characterStatus : MonoBehaviour {

    RectTransform auraBarRect;
    GameObject auraBar;
    public static bool inQTE;
    float shield;
    System.Random random;
    string QTEtext;
    RectTransform TwilightComponent;
    GameObject QteTwilight;
    GameObject firstQteBunch;
    GameObject QtePressable;
    Text pressableLetter;

    // Use this for initialization
    void Start () {
        QteTwilight = GameObject.Find("QteTwilight");
        TwilightComponent = QteTwilight.GetComponent<RectTransform>();
        auraBar = GameObject.Find("shield");
        auraBarRect = auraBar.GetComponent<RectTransform>();
        inQTE = false;
        shield = 1;
        random = new System.Random();
        QteTwilight.SetActive(false);
        firstQteBunch = GameObject.Find("firstQtePressableBunch");
        firstQteBunch.SetActive(false);
        QtePressable = firstQteBunch.transform.FindChild("QtePressable").gameObject;
        pressableLetter = QtePressable.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
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
        QteTwilight.SetActive(true);
        firstQteBunch.SetActive(true);
        inQTE = true;
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
        pressableLetter.text = QTEtext;
    }
}
