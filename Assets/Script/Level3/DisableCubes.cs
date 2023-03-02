using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisableCubes : MonoBehaviour
{
    public GameObject[] Selector;
    public InputActionReference inputAction;
    // Start is called before the first frame update
    void Awake()
    {
        //inputAction.action.started += Toggle;
    }

    void OnDestroy()
    {
        if (inputAction != null) inputAction.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        Debug.Log("In Toggle");
        SelectLattice s;
        MeshRenderer m;
        if (context.performed)
        {
            for (int i = 0; i < Selector.Length; i++)
            {
                s = Selector[i].GetComponent<SelectLattice>();
                m = Selector[i].GetComponent<MeshRenderer>();
                Debug.Log(s.hover.ToString() + " " + i.ToString());
                if (!s.hover) m.enabled = false;
            }
        }
    }
}
