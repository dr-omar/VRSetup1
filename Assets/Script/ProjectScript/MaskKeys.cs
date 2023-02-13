using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // include so we can load new scenes

public class MaskKeys : MonoBehaviour
{
    [HideInInspector]
    public GameObject lastAtom = null;
    private int index = 0;
    public Canvas helpCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.F1)) {
            helpCanvas.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            helpCanvas.enabled = false;
        }
        if (lastAtom != null) {
            if (Input.GetKeyDown (KeyCode.N)) {
                Vector3 v = lastAtom.transform.localScale;
                lastAtom.transform.localScale = new Vector3 (v.x + 0.1f, v.y + 0.1f, v.z + 0.1f);
            }
            if (Input.GetKeyDown (KeyCode.M)) {
                Vector3 v = lastAtom.transform.localScale;
                lastAtom.transform.localScale = new Vector3 (v.x - 0.1f, v.y - 0.1f, v.z - 0.1f);
            }
            if (Input.GetKeyDown (KeyCode.C)) {
                MeshRenderer gRenderer = lastAtom.GetComponent<MeshRenderer>();
                switch (index) {
                case 0: gRenderer.material.color = Color.yellow; break;
                case 1: gRenderer.material.color = Color.cyan; break;
                case 2: gRenderer.material.color = Color.red; break;
                case 3: gRenderer.material.color = Color.green; break;
                case 4: gRenderer.material.color = Color.blue; break;
                case 5: gRenderer.material.color = Color.gray; break;
                case 6: gRenderer.material.color = Color.white; break;
                case 7: gRenderer.material.color = Color.black; break;
                case 8: gRenderer.material.color = Color.magenta; break;
                }
                index = (index+1) % 9;
            }
        }
    }
}
