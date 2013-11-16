using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {
	
	public GameObject PowerLine;
	public GameObject AimLine;
    public float SpeedMultiplier;
    public float Radius;
	private LineRenderer powerLine;
	private LineRenderer aimLine;
    private bool powerInc = true;
	private float power = 1F;
    private Vector3 lineHeight = new Vector3(0F, 0F, -1F);
    private float aimLineLength = 3F;
	
	// Use this for initialization
	void Start () {
        this.gameObject.collider.material.bounciness = 1F;
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

		float mouseDistance = (mousePos - objPos).magnitude;

		#region Manages drawing of the aiming and force LineRenderers
		if (this.gameObject.rigidbody.velocity.magnitude < 0.01F)
		{
            Vector3 linesEnd = (mousePos - objPos).normalized;
            this.gameObject.rigidbody.velocity = new Vector3(0F, 0F, 0F);
			//Debug.Log(mouseDistance);
			if (mouseDistance < 20F)
			{
                aimLine.SetPosition(0, (objPos + linesEnd * Radius) + lineHeight);
				aimLine.SetPosition(1, (objPos + linesEnd * aimLineLength) + lineHeight);
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				powerLineVector = linesEnd * power;
                if (power - Radius >= 10F || power - Radius <= 0F)
                {
                    powerInc = !powerInc;
                }
                if (powerInc)
                {
                    power += 0.07F;
                }
                else
                {
                    power -= 0.07F;
                }
                powerLine.SetPosition(0, (objPos + linesEnd * Radius) + lineHeight);
				powerLine.SetPosition(1, (objPos + powerLineVector) + lineHeight);
			}
			else if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				powerLineVector = linesEnd * power;
				power = 1F;
				this.gameObject.transform.rigidbody.AddForce(powerLineVector * SpeedMultiplier);
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
			aimLine.SetPosition(0, objPos);
			aimLine.SetPosition(1, objPos);
			powerLine.SetPosition(0, objPos);
			powerLine.SetPosition(1, objPos);
            if (this.gameObject.rigidbody.velocity.magnitude > 1.8F)
            {
                this.gameObject.rigidbody.drag = 0.25F;
            }
            else
            {
                this.gameObject.rigidbody.drag = 1.9F;
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
