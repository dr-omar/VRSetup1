using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class SelectLattice : MonoBehaviour
//public class SelectLattice : XRGrabInteractable
{
    [HideInInspector]
    public bool hover = false;

    public GameObject[] Selector;
    //public GameObject player;
    private MeshRenderer meshRenderer = null;
    public InputActionReference inputAction = null;
    //private bool isSelectedActive;
    //private MouseLooker m_MouseLookerPlayer;
    //private MouseLooker m_MouseLookerLattice;
    //private Transform parent;
    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        inputAction.action.started += Toggle;
    }

    void OnDestroy()
    {
        if (inputAction != null) inputAction.action.started -= Toggle;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("hover=" + hover.ToString() + gameObject.name);
    }
    
    void OnMouseOver()
    {
        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.Log("Mouse Hover");
                for (int i = 0; i < Selector.Length; i++)
                    Selector[i].GetComponent<MeshRenderer>().enabled = false;
                meshRenderer.enabled = true;
            }
        }
    }
    
    public void OnHoverEntered (HoverEnterEventArgs args)
    {
        //Debug.Log(args.interactorObject);

        //if (args.interactableObject == gameObject.name)
        if (gameObject.name == "Cube (2)")
        {
            hover = true;
            Debug.Log("hover" + hover.ToString() + gameObject.name);
        }
        //gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    public void OnHoverExited (HoverExitEventArgs args)
    {
        //Debug.Log(args.interactorObject);

        //if (args.interactableObject == gameObject.name)
        if (gameObject.name == "Cube (2)")
        {
            hover = false;
            Debug.Log("hover" + hover.ToString() + gameObject.name);
        }
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    
    public void Toggle (InputAction.CallbackContext context)
    {
        if (gameObject.name == "Cube (2)")
        {
            Debug.Log("Toggle " + gameObject.name + " " + hover.ToString());
            if (context.performed)
            {

                if (hover)
                {

                    meshRenderer.enabled = true;
                }
                else
                {
                    meshRenderer.enabled = false;
                }
            }
        }
    }
}