using UnityEngine;
using System.Collections;
using System;

public class StickyWall : MonoBehaviour {

    private Collider[] colliders;
    private Collider actualCollider;
    private float playerBounciness;
    private float playerDrag;
    private Vector3 incomingV;
    private Vector3 outgoingV;

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider player)
    {
        playerDrag = player.rigidbody.drag;
        incomingV = new Vector3(player.rigidbody.velocity.x, player.rigidbody.velocity.y, 0F);

        //other.material.bounceCombine = PhysicMaterialCombine.Minimum;
        //other.material.bounciness = 0F;
        player.rigidbody.drag = 0F;
    }

    void OnTriggerExit(Collider player)
    {
        player.rigidbody.drag = playerDrag;
        player.rigidbody.velocity = outgoingV; //FUCK YEAH MOTHERFUCKER
    }

    void OnCollisionEnter(Collision info)
    {
        outgoingV = incomingV + 2 * (Vector3.Dot(-incomingV, info.contacts[0].normal) * info.contacts[0].normal);
    }

}
