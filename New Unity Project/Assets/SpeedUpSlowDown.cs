using UnityEngine;
using System.Collections;

public class SpeedUpSlowDown : MonoBehaviour {

    public Texture Up;
    public Texture Down;
    private GameObject Player;
    private bool InTrigger = false;
    public float Force = 30;
    private float angle;
    private Vector3 slowDown;

	// Use this for initialization
	void Start () {

        if (Force > 0F)
        {
            this.gameObject.renderer.material.mainTexture = Up;
            this.gameObject.renderer.material.color = new Color(1F, 0F, 0F, 1F);
        }
        else
        {
            this.gameObject.renderer.material.mainTexture = Down;
            this.gameObject.renderer.material.color = new Color(0F, 0.3F, 1F, 1F);
        }
        Player = GameObject.Find("Player");

        slowDown = new Vector3(0F, Force, 0F);
        angle = this.gameObject.transform.eulerAngles.z;
        
        slowDown = Quaternion.Euler(0F, 0F, angle) * slowDown;
        
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
}