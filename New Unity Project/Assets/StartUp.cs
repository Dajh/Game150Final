using UnityEngine;
using System.Collections;

public class StartUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            wall.renderer.material.color = new Color(0.55F, 0.3F, 0.8F, 0.8F);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
