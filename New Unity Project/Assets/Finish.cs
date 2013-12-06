using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

    [HideInInspector]
    public bool finished = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter()
    {
        Debug.Log("finishmenu");
        finished = true;
    }

    void OnGUI()
    {
        if (finished)
        {
            GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2), 80, 20), "Level 1");
            GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2) + 20, 80, 20), "Level 2");
            GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2) + 40, 80, 20), "Level 3");
        }
    }
}
