using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float maxZoom = 12;
    public float minZoom = 22;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
                float nextOrthoSize = this.gameObject.camera.orthographicSize + -(Input.GetAxis("Mouse ScrollWheel") * 5);
                if (nextOrthoSize > maxZoom && nextOrthoSize < minZoom)
                {
                    this.gameObject.camera.orthographicSize = nextOrthoSize;
                }
            }
	}
}
