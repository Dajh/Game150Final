using UnityEngine;
using System.Collections;
using System;

public class Checkpoint : MonoBehaviour {

    private GameObject playerObject;
    private Motor playerMotor;
    private Collider[] colliders;
    private Collider triggerCollider;
    private Collider actualCollider;
    private bool stopMe = false;

	// Use this for initialization
	void Start () {
        this.gameObject.renderer.material.color = new Color(0.1F, 0.75F, 1F, 1F);

        int n = 0;
        int i = -1;
        int w = -1;
        colliders = this.GetComponents<Collider>();
        for (int j = 0; j < colliders.Length; j++)
        {
            if (colliders[j].isTrigger == true)
            {
                n++;
                i = j;
            }
            if (colliders[j].isTrigger == false)
            {
                w = j;
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
            triggerCollider = colliders[i];
            actualCollider = colliders[w];
        }

        playerObject = GameObject.Find("Player");
        playerMotor = playerObject.GetComponent<Motor>();
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

    void OnCollisionEnter()
    {
        if (stopMe)
        {
            playerMotor.inTheOpen = false;
            playerObject.rigidbody.velocity = Vector3.zero;
            triggerCollider.enabled = false;
            actualCollider.enabled = false;
        }
    }
}
