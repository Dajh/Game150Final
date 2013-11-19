using UnityEngine;
using System.Collections;
using System;

public class StickyWall : MonoBehaviour {

    private Collider[] colliders;
    private Collider actualCollider;
    private float otherBounciness;
    private float actualColliderBounciness;
    private float otherDrag;
    private PhysicMaterialCombine otherBCombine;
    private PhysicMaterialCombine actualColliderBCombine;
    private Vector3 incomingV;

	// Use this for initialization
	void Start () {
        int n = 0;
        int i = -1;
        colliders = this.GetComponents<Collider>();
        for (int j = 0; j < colliders.Length; j++)
        {
            if (colliders[j].isTrigger == false)
            {
                n++;
                i = j;
            }
        }
        if (n > 1)
        {
            throw new Exception("You have too many colliders jackass");
        }
        else if (n == 0)
        {
            throw new Exception("You have no colliders wtf");
        }
        else
        {
            actualCollider = colliders[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered trigger");
        actualColliderBCombine = actualCollider.material.bounceCombine;
        actualColliderBounciness = actualCollider.material.bounciness;
        otherBCombine = other.material.bounceCombine;
        otherBounciness = other.material.bounciness;
        otherDrag = other.rigidbody.drag;
        incomingV = new Vector3(other.rigidbody.velocity.x, other.rigidbody.velocity.y, 0F);

        actualCollider.material.bounceCombine = PhysicMaterialCombine.Minimum;
        actualCollider.material.bounciness = 0F;
        other.material.bounceCombine = PhysicMaterialCombine.Minimum;
        other.material.bounciness = 0F;
        other.rigidbody.drag = 0F;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("exited");
        actualCollider.material.bounceCombine = actualColliderBCombine;
        actualCollider.material.bounciness = actualColliderBounciness;
        other.material.bounceCombine = otherBCombine;
        other.material.bounciness = otherBounciness;
        other.rigidbody.drag = otherDrag;

        //yield return new WaitForSeconds(0.1F);
        other.rigidbody.velocity = new Vector3(0F, 0F, 0F);
        other.rigidbody.velocity = incomingV;
    }

}
