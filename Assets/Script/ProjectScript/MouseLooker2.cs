using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLooker2 : MonoBehaviour {

	// Use this for initialization
	public float XSensitivity = 20f;
	public float YSensitivity = 20f;

	Vector3 mousePos;
	bool altKeyPressed = false, ctrlKeyPressed = false;
	
	void Update() {
		// rotate stuff based on the mouse
		//LookRotation (); 
		if (altKeyPressed)
        {
			mousePos = Mouse.current.delta.ReadValue();
			float yRot = mousePos.x * XSensitivity * Time.deltaTime;
			gameObject.transform.Rotate(0, yRot, 0, Space.World);
		}
		if (ctrlKeyPressed)
		{
			mousePos = Mouse.current.delta.ReadValue();
			float zRot = mousePos.y * YSensitivity * Time.deltaTime;
			gameObject.transform.Rotate(0, 0, zRot, Space.World);
		}


	}
	public void HorizontalRotation (InputAction.CallbackContext context)
    {
		if (context.performed)
        {
			altKeyPressed = true;
        }
		if (context.canceled)
        {
			altKeyPressed = false;
        }
    }
	public void VerticalRotation(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			ctrlKeyPressed = true;
		}
		if (context.canceled)
		{
			ctrlKeyPressed = false;
		}
	}
	/*
	public void LookRotation(InputAction.CallbackContext context)
	{
		mousePos = Vector3.zero;
		if (context.performed)
		{
			mousePos = Mouse.current.position.ReadValue();
			Debug.Log("mousePos=" + mousePos.x.ToString());
			Debug.Log("mousePosition=" + mousePosition.x.ToString());
		}
	*/
	/*
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
	*/
}
