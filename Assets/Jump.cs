using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("a")) {
            print("A has been let up");
        }
        else if (Input.GetKeyUp("d")) {
            print("D has been let up");
        }
    }
}
