using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {
	
	public GameObject PowerLine;
	public GameObject AimLine;
	public LineRenderer powerLine;
	public LineRenderer aimLine;
    private bool powerInc = true;
	private float power = 1F;
	
	// Use this for initialization
	void Start () {
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
		if (this.gameObject.rigidbody.velocity.magnitude == 0F)
		{
			//Debug.Log(mouseDistance);
			if (mouseDistance < 20F)
			{
				aimLine.SetPosition(0, objPos);
				aimLine.SetPosition(1, objPos + (mousePos - objPos).normalized * 3);
			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
				powerLineVector = (mousePos - objPos).normalized * power;
                if (power >= 10F || power <= 0F)
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
				powerLine.SetPosition(0, objPos);
				powerLine.SetPosition(1, objPos + powerLineVector);
			}
			else if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				powerLineVector = (mousePos - objPos).normalized * power;
				power = 1F;
				this.gameObject.transform.rigidbody.AddForce(powerLineVector * 120F);
				Debug.Log("powerV: " + powerLineVector.x + ", " + powerLineVector.y);
			}
			else
			{
				powerLineVector = objPos;
				powerLine.SetPosition(0, objPos);
				powerLine.SetPosition(1, objPos);
			}
			
			if (Input.GetKeyDown(KeyCode.Space))
			{
				//Debug.Log("Ball: " + objPos.normalized.x + "," + objPos.normalized.y);
				//Debug.Log("Mouse: " + mousePos.normalized.x + "," + mousePos.normalized.y);
				Debug.Log("powerV: " + powerLineVector.x + ", " + powerLineVector.y);
				//Debug.Log("mDist: " + mouseDistance);
			}
		}
		else
		{
			aimLine.SetPosition(0, objPos);
			aimLine.SetPosition(1, objPos);
			powerLine.SetPosition(0, objPos);
			powerLine.SetPosition(1, objPos);
            if (this.gameObject.rigidbody.velocity.magnitude > 0.3F)
            {
                this.gameObject.rigidbody.drag = 0.25F;
            }
            else
            {
                this.gameObject.rigidbody.drag = 3F;
            }
		}
		#endregion


	}
}
