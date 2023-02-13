using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using TMPro;

public class DropDownManager : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    public Transform periodicTable;
    public GameObject[] Lattice;
    private GameObject g;
    // Start is called before the first frame update
    private void Awake() {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    public void PrintedNewValue() {
        if (g!=null) {
            g.SetActive (false);
            dehighlight ();
        }
        int currentValue = dropdown.value;
        if (currentValue == 0) return;
        currentValue--;
        
        if (currentValue < Lattice.Length) {
            g = Lattice[currentValue];
            //Debug.Log (g);
            if (g) {
                g.SetActive(true);
                highlight (currentValue);
            }
        }
    }
   public void highlight(int v) {
        item[] a;
        Transform b;
        a=Globals.SimpleCubePo;
        switch (v) {
            case 0: a=Globals.SimpleCubePo; break;
            case 1: a=Globals.bcc; break;
            case 2: a=Globals.fcc; break;
            case 3: a=Globals.SimpleCubeSalt; break;
            case 4: a=Globals.fccDiamond; break;
            case 5: a=Globals.fccZincblende; break;
            //case 6: a=Globals.SimpleCubePo; break;
        }
        foreach (item s in a) {
            string c = "Canvas/"+s.name;
            b = periodicTable.transform.Find (c);
            b.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            b.GetComponent<Image>().color = new Color32 (255, 36, 94, 255);
        }
    }
    public void dehighlight() {
        dehighlightSingle (Globals.SimpleCubePo);
        dehighlightSingle (Globals.bcc);
        dehighlightSingle (Globals.fcc);
        dehighlightSingle (Globals.SimpleCubeSalt);
        dehighlightSingle (Globals.fccDiamond);
        dehighlightSingle (Globals.fccZincblende);
    }
    private void dehighlightSingle(item[] a) {
        Transform b;
        foreach (item s in a) {
            string c = "Canvas/"+s.name;
            b = periodicTable.transform.Find (c);
            b.transform.localScale = new Vector3(1f, 1f, 1f);
            b.GetComponent<Image>().color = s.color;
        }
    }
/*
    GameObject FindInActiveObjectByTag(string tag)
{
Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
    foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
    for (int i = 0; i < objs.Length; i++)
    {
        if (objs[i].hideFlags == HideFlags.None)
        {
            if (objs[i].CompareTag(tag))
            {
                return objs[i].gameObject;
            }
        }
    }
    return null;
}
    */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
