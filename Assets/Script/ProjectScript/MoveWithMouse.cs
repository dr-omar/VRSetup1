using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private Camera mainCamera;
    private float cameraZDistance;
    private int isMoving;
    [HideInInspector]
    public GameObject manager;
    private MaskKeys mk;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraZDistance = mainCamera.WorldToScreenPoint (transform.position).z + 5;
        isMoving = 0;
        manager = GameObject.FindGameObjectWithTag ("Manager4");
        mk = manager.GetComponent<MaskKeys>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == 0) {
            
            if (Input.GetMouseButtonDown(1)) {
                Destroy (gameObject);
                
                mk.lastAtom = null;
                return;
            }
            
            Vector3 ScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cameraZDistance);
            Vector3 NewWorldPosition = mainCamera.ScreenToWorldPoint (ScreenPosition);
            transform.position = NewWorldPosition;
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                cameraZDistance += 0.1f;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                cameraZDistance -= 0.1f;
            }
            
        }
         else {
            if (Input.GetMouseButtonDown(1) && isMoving==2) {
                isMoving = 0;
            }
        }
        
    }
    void OnMouseOver () {
        if (Input.GetMouseButtonDown(1) && isMoving == 1) {
            Assessment3.gm.subCount(gameObject);
            isMoving = 2;
        }
    }

    void OnTriggerStay (Collider other) {
        //Debug.Log (other.gameObject.name + " isMoving=" + isMoving.ToString());
        if (other.gameObject.name.Substring(0, 6) == "Sphere" && Input.GetKey(KeyCode.Mouse0) && isMoving == 0) {
            transform.position = other.transform.position;
            isMoving = 1;
            other.gameObject.SetActive (false);
            if (gameObject.tag == other.gameObject.tag) {
                Assessment3.gm.addCount(other.gameObject, gameObject, true);
            }
            else Assessment3.gm.addCount(other.gameObject, gameObject, false);
        }
    }
}
