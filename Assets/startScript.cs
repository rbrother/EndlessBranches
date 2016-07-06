using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        Debug.Log("OnMouseDown has been executed!");
        SceneManager.LoadScene("kentta1");
    }
}
