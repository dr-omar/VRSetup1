using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooker2 : MonoBehaviour {

	// Use this for initialization
	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	
	void Update() {
		// rotate stuff based on the mouse
		LookRotation ();
	}
	public void LookRotation()
	{
		if (Input.GetKey (KeyCode.LeftAlt)) {
			//get the y and x rotation based on the Input manager
			float yRot = Input.GetAxis("Mouse X") * XSensitivity;
			//float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

			gameObject.transform.Rotate (0, yRot, 0);
		}
		if (Input.GetKey (KeyCode.LeftControl)) {
			//get the y and x rotation based on the Input manager
			//float yRot = Input.GetAxis("Mouse X") * XSensitivity;
			float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

			gameObject.transform.Rotate (xRot, 0, 0);
		}
	}
}
