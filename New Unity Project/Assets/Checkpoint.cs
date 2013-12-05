using UnityEngine;
using System.Collections;
using System;

public class Checkpoint : MonoBehaviour {

    private GameObject playerObject;
    private SphereCollider playerCollider;
    private Motor playerMotor;
    private Collider[] colliders;
    private Collider triggerCollider;
    private Collider actualCollider;
    private bool stopMe = false;

	// Use this for initialization
	void Start () {
        this.gameObject.renderer.material.color = new Color(0.1F, 0.75F, 1F, 1F);
        this.gameObject.collider.material.bounciness = 0F;


        int n = 0;
        //int triggerIndex = -1;
        int colliderIndex = -1;
        colliders = this.GetComponents<Collider>();
        for (int j = 0; j < colliders.Length; j++)
        {
            if (colliders[j].isTrigger == true)
            {
                n++;
                //triggerIndex = j;
            }
            if (colliders[j].isTrigger == false)
            {
                colliderIndex = j;
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
            //triggerCollider = colliders[triggerIndex];
            actualCollider = colliders[colliderIndex];
        }

        playerObject = GameObject.Find("Player");
        playerMotor = playerObject.GetComponent<Motor>();
        playerCollider = playerObject.GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        stopMe = true;
        /*if (triggerCollider.enabled)
        {
            playerMotor.inTheOpen = false;
            playerObject.rigidbody.velocity = Vector3.zero;
            Debug.Log("hit trigger");
            Debug.Log(triggerCollider.enabled.ToString());
        }*/
    }

    void OnTriggerLeave()
    {
        actualCollider.enabled = true;
    }

    void OnCollisionEnter(Collision info)
    {
        if (stopMe)
        {
            playerMotor.inTheOpen = false;
            actualCollider.enabled = false;
            playerObject.rigidbody.velocity = Vector3.zero;
            info.rigidbody.transform.position = info.contacts[0].point - (info.contacts[0].normal.normalized * playerCollider.radius); //yeahbitch
            stopMe = false;            
        }
    }

}
