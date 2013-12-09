using UnityEngine;
using System.Collections;

public class MeshcolorForGamble : MonoBehaviour {

    public float r;
    public float g;
    public float b;
    public float a;

	// Use this for initialization
	void Start () {
        this.gameObject.renderer.material.color = new Color(r, g, b, a);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
