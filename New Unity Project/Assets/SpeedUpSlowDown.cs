﻿using UnityEngine;
using System.Collections;

public class SpeedUpSlowDown : MonoBehaviour {

    private GameObject Player;
    private bool InTrigger = false;
    public float Force = 30;
    private float angle;
    private Vector3 slowDown;
    private float[] suckmydick;

	// Use this for initialization
	void Start () {
        if (Force > 0F)
        {
            this.gameObject.renderer.material.color = new Color(1F, 0F, 0F, 0.5F);
        }
        else
        {
            this.gameObject.renderer.material.color = new Color(0F, 0F, 1F, 0.5F);
        }
        Player = GameObject.Find("Player");

        slowDown = new Vector3(0F, Force, 0F);
        angle = Mathf.RoundToInt(this.gameObject.transform.rotation.z) * (Mathf.PI / 180);
        Debug.Log(angle);
        suckmydick = new float[4] { Mathf.Cos(angle), -Mathf.Sin(angle), Mathf.Sin(angle), Mathf.Cos(angle) };
        foreach (float asdlfkj in suckmydick)
        {
            Debug.Log(asdlfkj);
        }
        slowDown = Rotate(slowDown, suckmydick);
        Debug.Log(slowDown.ToString());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (InTrigger)
        {
            Player.rigidbody.AddForce(slowDown);
        }
	}

    void OnTriggerEnter()
    {
        InTrigger = true;
    }

    void OnTriggerExit()
    {
        InTrigger = false;
    }

    public Vector3 Rotate(Vector3 fuck, float[] you)
    {
        return new Vector3((fuck.x * you[0] + fuck.y * you[1]), (fuck.x * you[2] + fuck.y + you[3]), 0F);
    }
}