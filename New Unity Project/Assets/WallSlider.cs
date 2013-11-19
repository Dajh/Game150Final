using UnityEngine;
using System.Collections;

public class WallSlider : MonoBehaviour {

    /*private float initialBounceOther;
    private float initialBounceThis;
    private PhysicMaterialCombine initialBounceCombineOther;
    private PhysicMaterialCombine initialBounceCombineThis;
    private Vector3 incomingVelocity;*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*void OnCollisionEnter(Collision collision)
    {
        incomingVelocity = new Vector3(collision.rigidbody.velocity.x, collision.rigidbody.velocity.y, 0F);

        initialBounceOther = collision.collider.material.bounciness;
        collision.rigidbody.collider.material.bounciness = 0;

        initialBounceCombineOther = collision.rigidbody.collider.material.bounceCombine;
        collision.rigidbody.collider.material.bounceCombine = PhysicMaterialCombine.Minimum;

        initialBounceThis = this.gameObject.collider.material.bounciness;
        this.gameObject.collider.material.bounciness = 0;

        initialBounceCombineThis = this.gameObject.collider.material.bounceCombine;
        this.gameObject.collider.material.bounceCombine = PhysicMaterialCombine.Minimum;

        Debug.Log(collision.rigidbody.collider.material.bounciness);
    }

    void OnCollisionExit(Collision collision)
    {
        collision.rigidbody.collider.material.bounciness = initialBounceOther;
        collision.rigidbody.collider.material.bounceCombine = initialBounceCombineOther;

        this.gameObject.collider.material.bounciness = initialBounceThis;
        this.gameObject.collider.material.bounceCombine = initialBounceCombineThis;

        collision.rigidbody.velocity = incomingVelocity;
    }*/
}
