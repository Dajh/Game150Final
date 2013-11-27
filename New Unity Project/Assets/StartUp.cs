using UnityEngine;
using System.Collections;

public class StartUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            //Debug.Log(wall.collider.material.name);
            wall.renderer.material.color = new Color(0.55F, 0.3F, 0.8F, 0.8F);
            wall.collider.material = new PhysicMaterial();
            wall.collider.material.bounciness = 1F;
            wall.collider.material.bounceCombine = PhysicMaterialCombine.Average;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
