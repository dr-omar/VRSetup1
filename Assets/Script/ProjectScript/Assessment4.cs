using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using TMPro;

public class Assessment4 : MonoBehaviour
{

    public GameObject QuestionPanel;
    public TextMeshProUGUI Question;
    public GameObject PanelObject;

    [HideInInspector] // Hides var below
    public int currentQIndex;
    // Start is called before the first frame update
    void Start()
    {
        DateTime epochStart = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int currentEpochTime = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        UnityEngine.Random.InitState (currentEpochTime);
        currentQIndex = UnityEngine.Random.Range (0, Globals.ENDQUESTIONS3);
        showQuestion();
    }

    public void showQuestion() {
        /*
        if (currentQIndex == Globals.ENDQUESTIONS2) {
            endAssessment();
            return;
        }
        */
        string st = "";
        switch (currentQIndex) {
            case 0: st = "Hunt the Simple Cubic (Polonium)"; break;
            case 1: st = "Hunt the Body Centered Cubic (Iron)"; break;
            case 2: st = "Hunt the Face Centered Cubic (Nickel)"; break;
            case 3: st = "Hunt the Face Centered Cubic (Salt)"; break;
            case 4: st = "Hunt the Face Sub Group (Diamond)"; break;
            case 5: st = "Hunt the Face Sub Group (Zincblende)"; break;
            case 6: st = "Hunt the Body Centered cubic (CsCl)"; break;
        }
        Question.text = st;
        QuestionPanel.SetActive(true);
    }
}
