using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using TMPro;

public class Assessment2 : MonoBehaviour
{

    public GameObject[] Lattice;
    public GameObject[] SelectorCubes;
    public GameObject QuestionPanel;
    public TextMeshProUGUI Question;
    public GameObject StartAssessmentButton;
    public GameObject SubmitButton;
    public GameObject PanelObject;
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
        while (maxIndex<Globals.ENDQUESTIONS2) {
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

    public void showOption (int a, Vector3 v) {
        Lattice[a].SetActive(true);
        Transform t = Lattice[a].GetComponent<Transform>();
        t.position = v;
    }

    public void showQuestion() {
        int qno;
        if (currentQIndex == Globals.ENDQUESTIONS2) {
            endAssessment();
            return;
        }
        if (currentQIndex > 0) {
            qno = bookKeepQuestions[currentQIndex-1];
            Lattice[Globals.q2[qno].option1].SetActive (false);
            Lattice[Globals.q2[qno].option2].SetActive (false);
            Lattice[Globals.q2[qno].option3].SetActive (false);
            Lattice[Globals.q2[qno].option4].SetActive (false);
        }
        for (int i=0; i<SelectorCubes.Length; i++) {
            SelectorCubes[i].GetComponent<MeshRenderer>().enabled = false;
            //SelectorCubes[i].SetActive (true);
            //Transform t = SelectorCubes.GetComponent<Transform>();
        }

        qno = bookKeepQuestions[currentQIndex++];
        //Debug.Log (qno);
        Question.text = currentQIndex.ToString() + ") " + Globals.q2[qno].question;
        showOption (Globals.q2[qno].option1, new Vector3 (-10, 1.5f, 15));
        showOption (Globals.q2[qno].option2, new Vector3 (0, 1.5f, 15));
        showOption (Globals.q2[qno].option3, new Vector3 (10, 1.5f, 15));
        showOption (Globals.q2[qno].option4, new Vector3 (20, 1.5f, 15));
        QuestionPanel.SetActive(true);
    }
    void endAssessment() {
        PanelObject.SetActive (false);
        ScoreObject.SetActive (true);
        TextMeshPro t = ScoreObject.GetComponent<TextMeshPro>();
        t.text = "Assessment End\nAssessment Score: " + Score.ToString() + " / " + Globals.ENDQUESTIONS2.ToString();
        SubmitButton.SetActive (false);
    }
}
