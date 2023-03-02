using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using TMPro;

public class DropDownManager1 : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Transform periodicTable;
    //public TMP_InputField mainInput;
    public GameObject[] Lattice;
    private GameObject g;

    private void Awake()
    {
        if (dropdown == null) dropdown = GetComponent<TMP_Dropdown>();
    }

    public void DropDownChange()
    {
        int index = dropdown.value;
        if (g != null)
        {
            g.SetActive(false);
            dehighlight();
        }
        if (index > 0)
        {
            g = Lattice[index - 1];
            g.SetActive(true);
            highlight(index - 1);
        }
    }
    public void highlight(int v)
    {
        item[] a;
        Transform b;
        a = Globals.SimpleCubePo;
        switch (v)
        {
            case 0: a = Globals.SimpleCubePo; break;
            case 1: a = Globals.bcc; break;
            case 2: a = Globals.fcc; break;
            case 3: a = Globals.SimpleCubeSalt; break;
            case 4: a = Globals.fccDiamond; break;
            case 5: a = Globals.fccZincblende; break;
                //case 6: a=Globals.SimpleCubePo; break;
        }
        foreach (item s in a)
        {
            string c = "Canvas/" + s.name;
            b = periodicTable.transform.Find(c);
            b.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            b.GetComponent<Image>().color = new Color32(255, 36, 94, 255);
        }
    }
    public void dehighlight()
    {
        dehighlightSingle(Globals.SimpleCubePo);
        dehighlightSingle(Globals.bcc);
        dehighlightSingle(Globals.fcc);
        dehighlightSingle(Globals.SimpleCubeSalt);
        dehighlightSingle(Globals.fccDiamond);
        dehighlightSingle(Globals.fccZincblende);
    }
    private void dehighlightSingle(item[] a)
    {
        Transform b;
        foreach (item s in a)
        {
            string c = "Canvas/" + s.name;
            b = periodicTable.transform.Find(c);
            b.transform.localScale = new Vector3(1f, 1f, 1f);
            b.GetComponent<Image>().color = s.color;
        }
    }
}
