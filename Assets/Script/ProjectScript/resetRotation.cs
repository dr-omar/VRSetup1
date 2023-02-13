using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset () {
        //Quaternion q = Quaternion.identity;
        //Vector3 v = q.ToEulerAngles();
        transform.localEulerAngles = new Vector3(0,0,0);
        
        //Vector3 rotationToAdd = new Vector3(45, 90, 0);
        ///transform.Rotate(-v);
    }
}
