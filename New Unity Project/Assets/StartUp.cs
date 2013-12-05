using UnityEngine;
using System.Collections;

public class StartUp : MonoBehaviour {

    [HideInInspector]
    public int shotCount = 0;
    [HideInInspector]
    public int timer = 0;
    [HideInInspector]
    public bool timerStart = false;
    private int frameIndex = 0;
    private GUIStyle timerStyle = new GUIStyle();


	// Use this for initialization
	void Start () {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject plane = GameObject.FindGameObjectWithTag("Plane");
        plane.collider.material.staticFriction = 0F;
        plane.collider.material.dynamicFriction = 0F;
        plane.collider.material.frictionCombine = PhysicMaterialCombine.Multiply;
        foreach (GameObject wall in walls)
        {
            //Debug.Log(wall.collider.material.name);
            wall.renderer.material.color = new Color(0.55F, 0.3F, 0.8F, 0.8F);
            wall.collider.material = new PhysicMaterial();
            wall.collider.material.bounciness = 1F;
            wall.collider.material.bounceCombine = PhysicMaterialCombine.Maximum;
            wall.collider.material.staticFriction = 0F;
            wall.collider.material.dynamicFriction = 0F;
            wall.collider.material.frictionCombine = PhysicMaterialCombine.Multiply;
        }
        timerStyle.fontSize = 22;
        timerStyle.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (timerStart)
        {
            if (frameIndex < 61)
            {
                frameIndex++;
            }
            else
            {
                frameIndex = 0;
                timer++;
            }
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 5, 100, 40), string.Format("{0}:{1}", (timer / 60).ToString("00"), (timer % 60).ToString("00")), timerStyle);
        GUI.Label(new Rect(10, 40, 100, 40), string.Format("Shots taken: {0}", shotCount), timerStyle);
    }
}
