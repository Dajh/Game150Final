using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

    [HideInInspector]
    public bool finished = false;
    private StartUp startUp;
    GUIStyle messageStyle = new GUIStyle();

	// Use this for initialization
	void Start () {
        startUp = GameObject.Find("GlobalScripts").GetComponent<StartUp>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter()
    {
        //Debug.Log("finishmenu");
        finished = true;
        startUp.timerStart = false;
    }

    void OnGUI()
    {
        if (finished)
        {
            messageStyle.fontSize = 20;
            messageStyle.normal.textColor = Color.white;
            GUI.TextArea(new Rect((Screen.width / 2), (Screen.height / 2) - 80, 140, 80), "Level Complete! \r\nChoose another level to play, \r\nor quit:", messageStyle);
            if (GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2), 80, 20), "Level 1"))
            {
                Application.LoadLevel("Level 1");
            }
            if (GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2) + 20, 80, 20), "Level 2"))
            {
                Application.LoadLevel("Level 2");
            }
            if (GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2) + 40, 80, 20), "Level 3"))
            {
                Application.LoadLevel("Level 3");
            }
            if (GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2) + 60, 80, 20), "Quit"))
            {
                Application.Quit();
            }
        }
    }
}
