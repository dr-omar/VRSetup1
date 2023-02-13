using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SpawnSphere : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 objectPos;
	public GameObject yourPrefab;
    private GameObject g = null;
    [HideInInspector]
    public GameObject manager;
    private MaskKeys mk;
    // Start is called before the first frame update
    void Start()
    {}


    // Update is called once per frame
    void Update()
    {}

    public void createSphere () {
        if (Assessment3.gm.isAtomSpawned) {
            Destroy (Assessment3.gm.atomSpawned);
        }
        mousePos = Input.mousePosition;
        mousePos.z = 5.0f;
        objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        g = Instantiate(yourPrefab, objectPos, Quaternion.identity);
        
        g.GetComponent<MoveWithMouse>().enabled = true;
        string name =  EventSystem.current.currentSelectedGameObject.name; // button name
        g.tag = name; // spawned object tag name
        
        g.name = g.name + Assessment3.Atoms.Count.ToString();
        Assessment3.gm.setParent (g);
        Assessment3.gm.isAtomSpawned = true;
        Assessment3.gm.atomSpawned = g;

        manager = GameObject.FindGameObjectWithTag ("Manager4");
        //Debug.Log (manager);
        mk = manager.GetComponent<MaskKeys>();
        mk.lastAtom = g;
        //manager.lastAtom = g;
    }
}
