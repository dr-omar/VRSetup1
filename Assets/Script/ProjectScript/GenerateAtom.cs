using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateAtom : MonoBehaviour
{
    public Button[] buttons;
    //private Rigidbody rigidbody;
    private Camera cam;
    private GameObject sphere;
    private bool isSphereSet;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        for (int i=0; i<buttons.Length; i++) {
            int temp = i;
            buttons[i].onClick.AddListener(() => generate(buttons[temp].name)); 
        }
        isSphereSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isSphereSet) {
            Vector3 mouse = Input.mousePosition;
            mouse.z = -cam.transform.position.z;
            Vector3 mouseWorld = cam.ScreenToWorldPoint (mouse);
            sphere.transform.position = mouseWorld;
        }
        
        
    }
    void generate (string name) {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
        //rigidbody = sphere.AddComponent<Rigidbody>(); // Add the rigidbody.
        Vector3 mouse = Input.mousePosition;
        mouse.z = -cam.transform.position.z;
        Debug.Log (mouse);
        Vector3 mouseWorld = cam.ScreenToWorldPoint (mouse);
        Debug.Log (mouseWorld);
        sphere.transform.position = mouseWorld;
        //rigidbody.position = mouseWorld;
        isSphereSet = true;
    }
}
