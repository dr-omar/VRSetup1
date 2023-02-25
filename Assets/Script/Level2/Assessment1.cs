using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using TMPro;

public class Assessment1 : MonoBehaviour
{

    public GameObject[] Lattice;
    public GameObject QuestionPanel;
    public TextMeshProUGUI Question;
    public GameObject StartAssessmentButton;
    public GameObject SubmitButton;
    public GameObject PanelObject;
    public Toggle Toggle1;
    public Toggle Toggle2;
    public Toggle Toggle3;
    public Toggle Toggle4;
    public GameObject ScoreObject;

    [HideInInspector] // Hides var below
    public int[] bookKeepQuestions;
    [HideInInspector] // Hides var below
    public int currentQIndex;
    private int len_questions;
    private int maxIndex;
    [HideInInspector] // Hides var below
    public bool AssessmentStarted;
    [HideInInspector] // Hides var below
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        len_questions = Globals.q1.Length;
        bookKeepQuestions = new int[7];
        DateTime epochStart = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int currentEpochTime = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        UnityEngine.Random.InitState (currentEpochTime);
        AssessmentStarted = false;
        Score = 0;
        maxIndex = 0;
        while (maxIndex<Globals.ENDQUESTIONS1) {
            int rnd = UnityEngine.Random.Range (0, len_questions-1);
            bool flag =false;
            for (int j=0; j<maxIndex && !flag; j++)
                if (rnd == bookKeepQuestions[j]) flag=true;
            if (!flag) 
                bookKeepQuestions[maxIndex++] = rnd;
        }
        currentQIndex = 0;
    }

    public void startAssessment() {
        StartAssessmentButton.SetActive(false);
        showQuestion();
    }

    public void showQuestion() {
        int qno, a;
        if (currentQIndex == Globals.ENDQUESTIONS1) {
            endAssessment();
            return;
        }
        if (currentQIndex > 0) {
            qno = bookKeepQuestions[currentQIndex-1];
            a = Globals.q1[qno].Lattice;
            if (a >= 0) {
                Lattice[a].SetActive(false);
            }
        }
        Toggle1.isOn = false;
        Toggle2.isOn = false;
        Toggle3.isOn = false;
        Toggle4.isOn = false;

        qno = bookKeepQuestions[currentQIndex++];
        //Debug.Log (qno);
        Question.text = currentQIndex.ToString() + ") " + Globals.q1[qno].question;
        Toggle1.GetComponentInChildren<Text> ().text = Globals.q1[qno].option1;
        Toggle2.GetComponentInChildren<Text> ().text = Globals.q1[qno].option2;
        Toggle3.GetComponentInChildren<Text> ().text = Globals.q1[qno].option3;
        Toggle4.GetComponentInChildren<Text> ().text = Globals.q1[qno].option4;
        a = Globals.q1[qno].Lattice;
        if (a >= 0) {
            Lattice[a].SetActive(true);
        }
        QuestionPanel.SetActive(true);
    }
    void endAssessment() {
        PanelObject.SetActive (false);
        ScoreObject.SetActive (true);
        TextMeshPro t = ScoreObject.GetComponent<TextMeshPro>();
        t.text = "Assessment End\nAssessment Score: " + Score.ToString() + " / " + Globals.ENDQUESTIONS1.ToString();
        SubmitButton.SetActive (false);
        
        
    }
}
