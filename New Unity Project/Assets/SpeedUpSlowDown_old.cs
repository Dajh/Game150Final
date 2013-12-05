using UnityEngine;
using System.Collections;

public class SpeedUpSlowDown_old : MonoBehaviour {

    private GameObject Player;
    private bool InTrigger = false;
    public float Force = 30;

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
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (InTrigger)
        {
            Vector3 slowDown = new Vector3(0F, -Force, 0F);
            float angle = this.gameObject.transform.rotation.z * (Mathf.PI / 180);
            Quaternion rotate = new Quaternion(Mathf.Cos(angle), -Mathf.Sin(angle), Mathf.Sin(angle), Mathf.Cos(angle));
            slowDown = rotate * slowDown;
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
}