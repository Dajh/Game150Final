using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    private GameObject playerObject;
    private Motor playerMotor;

	// Use this for initialization
	void Start () {
        playerObject = GameObject.Find("Player");
        playerMotor = playerObject.GetComponent<Motor>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        playerMotor.inTheOpen = false;
        other.rigidbody.velocity = new Vector3(0F, 0F, 0F);
        Debug.Log("hit trigger");
    }
}
