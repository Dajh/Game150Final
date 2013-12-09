using UnityEngine;
using System.Collections;
using System.IO;

public class Finish : MonoBehaviour {

    [HideInInspector]
    public bool finished = false;
    public AudioClip sfx;
    private StartUp startUp;
    GUIStyle messageStyle = new GUIStyle();
    private GUIStyle timerStyle = new GUIStyle();
    private string Scenes;

	// Use this for initialization
	void Start () {
        startUp = GameObject.Find("GlobalScripts").GetComponent<StartUp>();
        this.gameObject.renderer.material.color = new Color(0F, 1F, 0.2F, 1F);
        timerStyle.fontSize = 22;
        timerStyle.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter()
    {
        //Debug.Log("finishmenu");
        finished = true;
        startUp.timerStart = false;
        AudioSource.PlayClipAtPoint(sfx, this.transform.position);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 5, 100, 40), string.Format("{0}:{1}", (startUp.timer / 60).ToString("00"), (startUp.timer % 60).ToString("00")), timerStyle);
        GUI.Label(new Rect(10, 40, 100, 40), string.Format("Shots taken: {0}", startUp.shotCount), timerStyle);
        if (finished)
        {
            messageStyle.fontSize = 20;
            messageStyle.normal.textColor = Color.white;
            GUI.TextArea(new Rect((Screen.width / 2), (Screen.height / 2) - 80, 140, 80), "Level Complete! \r\nChoose another level to play, \r\nor quit:", messageStyle);
            for (int i = 0; i < Application.levelCount; i++)
            {
                if (GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2) + (i - 1) * 20, 80, 20), string.Format("Level {0}", i + 1)))
                {
                    Application.LoadLevel(string.Format("Level {0}", i));
                }
            }
                
            /*if (GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2) + 20, 80, 20), "Level 2"))
            {
                Application.LoadLevel("Level 2");
            }
            if (GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2) + 40, 80, 20), "Level 3"))
            {
                Application.LoadLevel("Level 3");
            }*/
            if (GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2) + (Application.levelCount - 1) * 20, 80, 20), "Quit"))
            {
                Application.Quit();
            }
        }
    }
}
