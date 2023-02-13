using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooker1 : MonoBehaviour {

	// Use this for initialization
	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	void Start() {
		// start the game with the cursor locked
		//LockCursor (true);
	}

	void Update() {
		// rotate stuff based on the mouse
		LookRotation ();

		// if ESCAPE key is pressed, then unlock the cursor
		//if(Input.GetButtonDown("Cancel")){
		//	LockCursor (false);
		//}

		// if the player fires, then relock the cursor
		//if(Input.GetButtonDown("Fire1")){
		//	LockCursor (true);
		//}
	}

	private void LockCursor(bool isLocked)
	{
		if (isLocked) 
		{
			// make the mouse pointer invisible
			Cursor.visible = false;

			// lock the mouse pointer within the game area
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			// make the mouse pointer visible
			Cursor.visible = true;

			// unlock the mouse pointer so player can click on other windows
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void LookRotation()
	{
		//get the y and x rotation based on the Input manager
		float yRot = Input.GetAxis("Mouse X") * XSensitivity;
		float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

		gameObject.transform.Rotate (-xRot, yRot, 0);
	}
}
