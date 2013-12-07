using UnityEngine;
using System.Collections;
using System;

public class StickyWall : MonoBehaviour {

    private Collider[] colliders;
    private Collider actualCollider;
    private float playerBounciness;
    private float playerDrag;
    private float playerFriction;
    private Vector3 incomingV;
    private Vector3 outgoingV;
	private bool actuallyCollided = false;

	// Use this for initialization
	void Start () {
        this.gameObject.renderer.material.color = new Color(1F, 1F, 0F, 1F);
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

        actualCollider.material.bounciness = 0F;
        actualCollider.material.frictionCombine = PhysicMaterialCombine.Multiply;
        actualCollider.material.dynamicFriction = 0F;
        actualCollider.material.staticFriction = 0F;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider player)
    {
	//Debug.Log("triggerenter");
        playerDrag = player.rigidbody.drag;
        playerFriction = player.material.dynamicFriction;
        incomingV = new Vector3(player.rigidbody.velocity.x, player.rigidbody.velocity.y, 0F);

        //other.material.bounceCombine = PhysicMaterialCombine.Minimum;
        //other.material.bounciness = 0F;
    }

    void OnTriggerExit(Collider player)
    {
	//Debug.Log("triggerleave");
		if (actuallyCollided) 
		{
			player.rigidbody.drag = playerDrag;
            player.material.dynamicFriction = playerFriction;
			player.rigidbody.velocity = Vector3.zero;
			player.rigidbody.velocity = outgoingV;
			actuallyCollided = false;
		}
    }

    void OnCollisionEnter(Collision info)
    {
	//Debug.Log("collisionenter");
    //Debug.Log(info.collider.name);
		info.collider.rigidbody.drag = 0F;
        info.collider.material.dynamicFriction = 0F;
        outgoingV = incomingV + 2 * (Vector3.Dot(-incomingV, info.contacts[0].normal) * info.contacts[0].normal);
		actuallyCollided = true;
    }

    void OnCollisionStay(Collision info)
    {
        //Debug.Log(incomingV.x);
        info.collider.rigidbody.velocity = new Vector3(incomingV.x, 0F, 0F);
    }

}
