using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; // include so we can load new scenes

public class PlayerControllerLevel1 : MonoBehaviour {

    Vector2 MoveAxis;
    public float playerSpeed = 2f;
    public float playerRotation = 50f;
    private float inputX, inputZ;
    Vector3 moveDirection;
    private CharacterController myController;

    // Reference to projectile prefab to shoot
    //public GameObject projectile;
    //public float power = 10.0f;

    // Reference to AudioClip to play
    //public AudioClip shootSFX;

    private void Start () {
        myController = GetComponent<CharacterController>();
    }

	// Update is called once per frame
    private void Update() {
        // Determine how much should move in the z-direction
        //Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;
        //if (playerSpeed == 0) return;
        inputX = MoveAxis.x;
        inputZ = MoveAxis.y;



        //Vector3 mousePos = Mouse.current.position.ReadValue();
        //if (mousePos.x <= 100 && !(Keyboard.current.altKey.wasPressedThisFrame))
        //{
        //    gameObject.transform.Rotate(0, -playerRotation * Time.deltaTime, 0);
        //}
        //if (mousePos.x > Screen.width - 100 && !(Keyboard.current.altKey.wasPressedThisFrame))
        //{
        //    gameObject.transform.Rotate(0, playerRotation * Time.deltaTime, 0);
        //}

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
            if (playerRotation == 0) return;
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
    /*
    public void onPlayerFire (InputAction.CallbackContext context)
    {
        Debug.Log("onPlayerFire");
        if (context.performed)
        {
            Debug.Log("GameManager");
            if (GameManager.gm)
            {
                if (GameManager.gm.gameIsOver) return;
            }
            Debug.Log(power);
            if (power == 0) return;
            // if projectile is specified
            if (projectile)
            {
                Debug.Log("Projectile");
                // Instantiante projectile at the camera + 1 meter forward with camera rotation
                GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

                // if the projectile does not have a rigidbody component, add one
                if (!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }
                // Apply force to the newProjectile's Rigidbody component if it has one
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

                // play sound effect if set
                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    { // the projectile has an AudioSource component
                      // play the sound clip through the AudioSource component on the gameobject.
                      // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                    }
                    else
                    {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
                    }
                }
            }
        }
    }
    */
    public void onEscape(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

    