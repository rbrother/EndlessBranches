using UnityEngine;
using System.Collections;

public class WallJump : MonoBehaviour {

    Transform ukkoSkaalaus;
    SpriteRenderer ukkoSpriteRenderer;
    Sprite onWall;

    // Use this for initialization
    void Start () {
        ukkoSkaalaus = transform.FindChild("ukko");
        ukkoSpriteRenderer = ukkoSkaalaus.GetComponent<SpriteRenderer>();      
        onWall = Resources.Load("RoffeV2onWall", typeof(Sprite)) as Sprite;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
