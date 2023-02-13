using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTransform : MonoBehaviour {

	//private string MoveInputAxis = "Vertical";
	//private string TurnInputAxis = "Horizontal";

    // rotation that occurs in angles per second holding down input
    public float rotationRate = 100;

    // units moved per second holding down move input
    public float moveSpeed = 2;
    public float gravity = 9.81f;
    private float inputX, inputZ;
    Vector3 moveDirection;
    private CharacterController myController;

    private void Start () {
        myController = GetComponent<CharacterController>();
    }

	// Update is called once per frame
    private void Update() {
        // Determine how much should move in the z-direction
		//Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        Vector3 mousePos = Input.mousePosition;
        //Debug.Log("mousePos.x = " + mousePos.x.ToString());
        //Debug.Log("mousePos.x = " + mousePos.y.ToString());
        if (mousePos.x <= 100 && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))) {
            //get the y and x rotation based on the Input manager
		    float yRot = 50 * Time.deltaTime;
		    //float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

		    gameObject.transform.Rotate (0, -yRot, 0);
        }
        //Debug.Log ("Screen.width= " + Screen.width.ToString());
        if (mousePos.x > Screen.width - 100 && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))) {
            float yRot = 50 * Time.deltaTime;
            gameObject.transform.Rotate (0, yRot, 0);
        }
        //Debug.Log (transform.eulerAngles.x);
        /*
        if (mousePos.y > Screen.height - 500  && transform.eulerAngles.x < 320) {
            float xRot = 50 * Time.deltaTime;
            gameObject.transform.Rotate (-xRot, 0, 0);
        }
        */

        Vector3 moveDirection = new Vector3 (0, 0, inputZ);
        moveDirection = transform.TransformDirection (moveDirection);
        moveDirection *= moveSpeed;

        moveDirection.y -= gravity * Time.deltaTime;
        myController.Move (moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) {
            moveDirection = new Vector3 (inputX, 0, 0);
            moveDirection = transform.TransformDirection (moveDirection);
            moveDirection *= moveSpeed;
            moveDirection.y -= gravity * Time.deltaTime;

            myController.Move (moveDirection * Time.deltaTime);
        }
        else {
            // Rotate player
            transform.Rotate (0, inputX * rotationRate * Time.deltaTime, 0);
        }
    }
}

    