using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {
	
	public GameObject PowerLine;
	public GameObject AimLine;
    public float SpeedMultiplier = 140F;
    public float Radius = 0.5F;
    public float PowerIncrement = 0.07F;
    public float HighSpeedDrag = 0.25F;
    public float LowSpeedDrag = 1.9F;
    public float LowSpeedDragThreshold = 1.8F;
    public float LineLength = 10F;
	private LineRenderer powerLine;
	private LineRenderer aimLine;
    private bool powerInc = true;
	private float power = 1F;
    private Vector3 lineHeight = new Vector3(0F, 0F, -1F);
    private float aimLineLength = 3F;
    [HideInInspector]
    public bool inTheOpen = false;
    private Vector3 posBeforeLaunch = new Vector3();
    private GameObject[] checkpoints;
	
	// Use this for initialization
	void Start () {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        //this.gameObject.collider.material.bounciness = 1F;
		powerLine = PowerLine.GetComponent<LineRenderer>();
		powerLine.SetWidth(0.5f,0.5f);
		powerLine.SetVertexCount(2);
		powerLine.SetColors(new Color(1F, 0F, 0F, 1F), new Color(1F, 0F, 0F, 1F));
		aimLine = AimLine.GetComponent<LineRenderer>();
		aimLine.SetWidth(0.05f,0.05f);
		aimLine.SetVertexCount(2);
		aimLine.SetColors(new Color(0.8F, 0.8F, 0.8F, 0.8F), new Color(0.8F, 0.8F, 0.8F, 0.8F));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
		Vector3 objPos = this.gameObject.transform.position;
		Vector3 powerLineVector = objPos;
        Vector3[] aimLineVectors = new Vector3[2];

		float mouseDistance = (mousePos - objPos).magnitude;

		#region Manages drawing of the aiming and force LineRenderers
		if (this.gameObject.rigidbody.velocity.magnitude < 0.01F)
		{
            if (inTheOpen)
            {
                this.gameObject.rigidbody.position = posBeforeLaunch;
            }
            Vector3 linesEnd = (mousePos - objPos).normalized;
            this.gameObject.rigidbody.velocity = new Vector3(0F, 0F, 0F);
			//Debug.Log(mouseDistance);
			if (mouseDistance < 20F)
			{
                aimLineVectors[0] = (objPos + linesEnd * Radius) + lineHeight;
                aimLineVectors[1] = (objPos + linesEnd * aimLineLength) + lineHeight;
                aimLine.SetPosition(0, aimLineVectors[0]);
				aimLine.SetPosition(1, aimLineVectors[1]);
			}
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                posBeforeLaunch = objPos;
                //Debug.Log("Mouse0 pressed.");
            }
			if (Input.GetKey(KeyCode.Mouse0))
			{
				powerLineVector = (aimLineVectors[1] - aimLineVectors[0]).normalized * power;
                if (power - Radius >= LineLength || power - Radius <= 0F)
                {
                    powerInc = !powerInc;
                }
                if (powerInc)
                {
                    power += PowerIncrement;
                }
                else
                {
                    power -= PowerIncrement;
                }
                //Debug.Log("Power = " + power + " | LineRatio = " + (((objPos + powerLineVector) + lineHeight) - ((objPos + linesEnd * Radius) + lineHeight)).magnitude / power);
                powerLine.SetPosition(0, (objPos + linesEnd * Radius) + lineHeight);
				powerLine.SetPosition(1, (objPos + powerLineVector) + lineHeight);
			}
			else if (Input.GetKeyUp(KeyCode.Mouse0))
			{
                //Debug.Log("Mouse0 up");
                inTheOpen = true;
                powerLineVector = (aimLineVectors[1] - aimLineVectors[0]).normalized * power;
				power = 1F;
				this.gameObject.transform.rigidbody.AddForce(powerLineVector * SpeedMultiplier);
                foreach (GameObject obj in checkpoints)
                {
                    obj.collider.enabled = true;
                }
				//Debug.Log("powerV: " + powerLineVector.x + ", " + powerLineVector.y);
			}
			else
			{
				powerLineVector = objPos;
				powerLine.SetPosition(0, objPos);
				powerLine.SetPosition(1, objPos);
			}
		}
		else
		{
            aimLineVectors[0] = objPos;
            aimLineVectors[1] = objPos;
			aimLine.SetPosition(0, aimLineVectors[0]);
			aimLine.SetPosition(1, aimLineVectors[1]);
			powerLine.SetPosition(0, objPos);
			powerLine.SetPosition(1, objPos);
            if (this.gameObject.rigidbody.velocity.magnitude > LowSpeedDragThreshold)
            {
                this.gameObject.rigidbody.drag = HighSpeedDrag;
            }
            else
            {
                this.gameObject.rigidbody.drag = LowSpeedDrag;
            }
		}
		#endregion

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Ball: " + objPos.normalized.x + "," + objPos.normalized.y);
            //Debug.Log("Mouse: " + mousePos.normalized.x + "," + mousePos.normalized.y);
            //Debug.Log("V: " + this.gameObject.rigidbody.velocity.x + ", " + this.gameObject.rigidbody.velocity.y);
            //Debug.Log("mDist: " + mouseDistance);
            Debug.Log("vMag: " + this.gameObject.rigidbody.velocity.magnitude);
        }
	}
}
