using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class NextQuestion3 : MonoBehaviour
{
    //public GameObject question;
    public GameObject startAssessment;
    private Assessment3 a1;
    private void Start()
    {
        a1 = startAssessment.GetComponent<Assessment3>();
    }

    public void buttonNextPressed() {
        a1.evaluate();
        a1.showQuestion();
    }

}
