using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLattice : MonoBehaviour
{
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

    void OnMouseOver() {
         if (Input.GetMouseButtonDown (0)) {
            for (int i = 0; i < Selector.Length; i++)
                Selector[i].GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        /*
        if (isSelectedActive) {
            m_MouseLookerPlayer = player.GetComponent<MouseLooker>();
            m_MouseLookerPlayer.XSensitivity = 0;
            parent = transform.parent;
            parent = parent.transform.parent;
            m_MouseLookerLattice = parent.GetComponent<MouseLooker>();
            m_MouseLookerLattice.XSensitivity = 2;

        }
        */
    }
}

