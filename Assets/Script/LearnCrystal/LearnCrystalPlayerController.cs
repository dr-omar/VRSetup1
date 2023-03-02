using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LearnCrystalPlayerController : MonoBehaviour
{

    Vector2 MoveAxis;
    public float playerSpeed = 2f;
    public float playerRotation = 50f;
    private float inputX, inputZ;
    Vector3 moveDirection;
    private CharacterController myController;

    private bool altKeyPressed = false;
    private PlayerInput playerInput;

    private void Start()
    {
        myController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Determine how much should move in the z-direction
        //Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;
        inputX = 0;
        inputZ = 0;
        Vector2 MoveAxis = playerInput.actions["Move"].ReadValue<Vector2>();
        inputX = MoveAxis.x;
        inputZ = MoveAxis.y;



        Vector3 moveDirection = new Vector3(0, 0, inputZ);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= playerSpeed;
        myController.Move(moveDirection * Time.deltaTime);

        if (altKeyPressed)
        {
            //if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) {
            moveDirection = new Vector3(inputX, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= playerSpeed;
            //moveDirection.y -= gravity * Time.deltaTime;

            myController.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            // Rotate player
            transform.Rotate(0, inputX * playerRotation * Time.deltaTime, 0);
        }
        if (Mouse.current != null)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            if (mousePos.x <= 100 && !(Keyboard.current.altKey.wasPressedThisFrame))
            {
                gameObject.transform.Rotate(0, -playerRotation * Time.deltaTime, 0);
            }
            if (mousePos.x > Screen.width - 100 && !(Keyboard.current.altKey.wasPressedThisFrame))
            {
                gameObject.transform.Rotate(0, playerRotation * Time.deltaTime, 0);
            }
        }

    }
    public void PlayerSideMove(InputAction.CallbackContext context)
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
}

    