using UnityEngine;
using System.Collections;

public class NoFriction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.collider.material.frictionCombine = PhysicMaterialCombine.Minimum;
        this.gameObject.collider.material.dynamicFriction = 0F;
        this.gameObject.collider.material.dynamicFriction2 = 0F;
        if (this.gameObject.rigidbody == null)
        {
            this.gameObject.collider.material.staticFriction = 0F;
            this.gameObject.collider.material.staticFriction2 = 0F;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
