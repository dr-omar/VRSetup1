using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LearnCrystalPlayerController : MonoBehaviour {

    Vector2 MoveAxis;
    public float playerSpeed = 2f;
    public float playerRotation = 50f;
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
        inputX = MoveAxis.x;
        inputZ = MoveAxis.y;

        Vector3 mousePos = Mouse.current.position.ReadValue();
        if (mousePos.x <= 100 && !(Keyboard.current.altKey.wasPressedThisFrame))
        {
            gameObject.transform.Rotate(0, -playerRotation * Time.deltaTime, 0);
        }
        if (mousePos.x > Screen.width - 100 && !(Keyboard.current.altKey.wasPressedThisFrame))
        {
            gameObject.transform.Rotate(0, playerRotation * Time.deltaTime, 0);
        }
        
        Vector3 moveDirection = new Vector3(0, 0, inputZ);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= playerSpeed;
        myController.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            moveDirection = new Vector3(inputX, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= playerSpeed;
            myController.Move(moveDirection * Time.deltaTime);
        }
        else {
            const float contsValue = 0.1f;
            //Debug.Log (inputX);
            if (inputX > contsValue || inputX < -contsValue)
            {
                // Rotate player
                transform.Rotate(0, inputX * playerRotation * Time.deltaTime, 0);
            }
        }
    }
    public void onPlayerMove(InputAction.CallbackContext context)
    {
        MoveAxis = Vector2.zero;
        if (context.performed)
        {
            MoveAxis = context.ReadValue<Vector2>();  // return delta x, y, and z
        }
        //if (context.started) Debug.Log ("Started");
        //if (context.canceled) Debug.Log ("released");
    }
}

    