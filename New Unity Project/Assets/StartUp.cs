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
    [HideInInspector]
    public System.Random rand = new System.Random();
    


	// Use this for initialization
	void Start () {
        //Debug.Log(Application.levelCount);
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

}
