using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject menu;
    public Transform head;
    public float spawnDistance = 2;
    public float Height = 0;
    public bool use_height = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (use_height)
        {
            menu.transform.position = head.position + new Vector3(head.forward.x, head.forward.y, head.forward.z).normalized * spawnDistance;
        }
        else
        {
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }
        menu.transform.position = new Vector3 (menu.transform.position.x, Height, menu.transform.position.z);
        menu.transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
        menu.transform.forward *= -1;
    }
}
