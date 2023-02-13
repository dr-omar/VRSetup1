using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using TMPro;

public class DropDownManager1 : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    //public Transform periodicTable;
    //public TMP_InputField mainInput;
    public GameObject[] Lattice;
    private GameObject g;

    public void DropDownChange () {
        int index = dropdown.value;
        if (g!=null) {
            g.SetActive (false);
        }
        if (index > 0) {
            g = Lattice[index-1];
            g.SetActive (true);
        }
    }
}
