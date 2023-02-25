using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.XR.Interaction.Toolkit;


public class SelectLattice : MonoBehaviour
//public class SelectLattice : XRGrabInteractable
{
    private bool hover = false;

    public GameObject[] Selector;
    public GameObject player;
    //private bool isSelectedActive;
    private MouseLooker m_MouseLookerPlayer;
    private MouseLooker m_MouseLookerLattice;
    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        //isSelectedActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown (1)) {
            if (isSelectedActive) {
                Selector.SetActive (false);
                isSelectedActive = false;
                //m_MouseLookerPlayer = player.GetComponent<MouseLooker>();
                m_MouseLookerPlayer.XSensitivity = 2;
                m_MouseLookerLattice.XSensitivity = 0;
            }
        }
        */
    }
    
    void OnMouseEnter()
    {
        //Debug.Log("name=" + gameObject.name);
        hover = true;
        //gameObject.GetComponent<MeshRenderer>().enabled = true;
        /*
            if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < Selector.Length; i++)
                Selector[i].GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        */
    }
    void OnMouseExit()
    {
        hover = false;
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    /*
    public void OnRaySelect()
    {
        if (gameObject.tag == "SelecCube")
        {
            Debug.Log("aaaaaaaaa");
            for (int i = 0; i < Selector.Length; i++)
                Selector[i].GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    */
    /*
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("aaaaaaaaa");
        for (int i = 0; i < Selector.Length; i++)
            Selector[i].GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    */
    /*
    XRBaseInteractable m_Interactable;
    //Renderer m_Renderer;

    //static Color s_HoveredColor = new Color(0.929f, 0.094f, 0.278f);
    //static Color s_SelectedColor = new Color(0.019f, 0.733f, 0.827f);

    protected void OnEnable()
    {
        m_Interactable = GetComponent<XRBaseInteractable>();
        //m_Renderer = GetComponent<Renderer>();

        //m_Interactable.firstHoverEntered.AddListener(OnFirstHoverEntered);
        //m_Interactable.lastHoverExited.AddListener(OnLastHoverExited);
        m_Interactable.selectEntered.AddListener(OnFirstSelectEntered);
        m_Interactable.selectExited.AddListener(OnLastSelectExited);

        m_Interactable.activated.AddListener(OnActivated);
        m_Interactable.deactivated.AddListener(OnDeactivated);

        //UpdateColor();
        disableObject();
    }
    protected void OnDisable()
    {
        //m_Interactable.firstHoverEntered.RemoveListener(OnFirstHoverEntered);
        //m_Interactable.lastHoverExited.RemoveListener(OnLastHoverExited);
        m_Interactable.selectEntered.RemoveListener(OnFirstSelectEntered);
        m_Interactable.selectExited.RemoveListener(OnLastSelectExited);

        m_Interactable.activated.RemoveListener(OnActivated);
        m_Interactable.deactivated.RemoveListener(OnDeactivated);
    }

    //protected virtual void OnFirstHoverEntered(HoverEnterEventArgs args) => enableObject();

    //protected virtual void OnLastHoverExited(HoverExitEventArgs args) => disableObject();

    protected virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => enableObject();

    protected virtual void OnLastSelectExited(SelectExitEventArgs args) => disableObject();

    protected virtual void OnActivated(ActivateEventArgs args) => enableObject();
    protected virtual void OnDeactivated(DeactivateEventArgs args) => disableObject();
    */
    //protected void enableObject()
    //{
        //Debug.Log("AAAA");
        //gameObject.GetComponent<MeshRenderer>().enabled = true;
        
        /*
        var color = m_Interactable.isSelected
            ? s_SelectedColor
            : m_Interactable.isHovered
                ? s_HoveredColor
                : Color.white;
        m_Renderer.material.color = color;
        */
    //}
    //protected void disableObject()
    //{
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
    //}
    
    public void onHoverEnter ()
    {
        hover = true;
        //Debug.Log("onHoverEnter " + gameObject.name + " " + hover.ToString());
        //gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    public void onHoverExit ()
    {
        hover = false;
        //Debug.Log("onHoverExit " + gameObject.name + " " + hover.ToString());
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    public void onFire (InputAction.CallbackContext context)
    {
        //Debug.Log("onFire " + gameObject.name + " " + hover.ToString());
        if (context.performed)
        {
            
            if (hover)
            {

                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}