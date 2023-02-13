using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using TMPro; 

public class Assessment3 : MonoBehaviour
{

    public static Assessment3 gm;
    public GameObject[] Lattice;
    public GameObject QuestionPanel;
    public TextMeshProUGUI Question;
    public GameObject StartAssessmentButton;
    public GameObject SubmitButton;
    public GameObject PanelObject;
    public GameObject ScoreObject;
    public GameObject helpPanel;

    [HideInInspector] // Hides var below
    public int currentQIndex;
    private int len_questions;
    private int maxIndex;
    [HideInInspector] // Hides var below
    public bool AssessmentStarted;
    [HideInInspector] // Hides var below
    public int Score = 0;
    // Atoms generated structure
    public class AtomsGenerated {
        public GameObject shadowSphere;
        public GameObject atomSphere;
        public bool correct;
        public AtomsGenerated (GameObject n, GameObject s, bool c) {
            shadowSphere = n;
            atomSphere = s;
            correct = c;
        }
    }
    [HideInInspector] // Hides var below
    public static List<AtomsGenerated> Atoms = new List<AtomsGenerated>();
    [HideInInspector] // Hides var below
    public bool isAtomSpawned = false;
    [HideInInspector] // Hides var below
    public GameObject atomSpawned = null;
    private int[] bookKeepQuestions;
    private int totalUserQuestions = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        len_questions = Globals.ENDQUESTIONS3;        
        AssessmentStarted = false;
        Score = 0;
        currentQIndex = 0;
        if (gm == null)
			gm = this.gameObject.GetComponent<Assessment3>();
        bookKeepQuestions = new int[len_questions];
        DateTime epochStart = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int currentEpochTime = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        UnityEngine.Random.InitState (currentEpochTime);
        maxIndex = 0;
    }

    public void startAssessment() {
        StartAssessmentButton.SetActive(false);
        //helpPanel.SetActive (false);
        showQuestion();

    }

    public void showQuestion() {
        
        if (maxIndex == totalUserQuestions) {
            endAssessment();
            return;
        }
        
        int c=0;
        int rnd = 0;
        while (c<100) {
            rnd = UnityEngine.Random.Range (0, len_questions);
            rnd = 0;
            bool flag =false;
            for (int j=0; j<maxIndex && !flag; j++)
                if (rnd == bookKeepQuestions[j]) flag=true;
            if (!flag) {
                bookKeepQuestions[maxIndex] = rnd;
                break;
            }
            c++;
        }
        if (maxIndex > 0) {
            int prevIndex = bookKeepQuestions[maxIndex-1];
            Lattice[prevIndex].SetActive (false);
            foreach (AtomsGenerated a in Atoms) {
                a.atomSphere.SetActive (false);
            }
            Atoms.Clear();
        }
        currentQIndex = bookKeepQuestions[maxIndex];
        Lattice[currentQIndex].SetActive (true);
        switch (currentQIndex) {
            case 0: Question.text = ") Build the simple cube (Polonium) atomic structure.";
                    break;
            case 1: Question.text = ") Build the base centered cube (Iron) atomic structure.";
                    break;
            case 2: Question.text = ") Build the face centered cube (Nickel) atomic structure.";
                    break;
            case 3: Question.text = ") Build the face centered cube (salt) atomic structure.";
                    break;
            case 4: Question.text = ") Build the fcc subgroup (diamond) atomic structure.";
                    break;
            case 5: Question.text = ") Build the fcc subgroup (zincblende) atomic structure.";
                    break;
            case 6: Question.text = ") Build the fcc (CsCl) atomic structure.";
                    break;
        }
        maxIndex++;
        Question.text = maxIndex.ToString() + Question.text;
        QuestionPanel.SetActive(true);
    }
    void endAssessment() {
        PanelObject.SetActive (false);
        ScoreObject.SetActive (true);
        TextMeshPro t = ScoreObject.GetComponent<TextMeshPro>();
        t.text = "Assessment End\nAssessment Score: " + Score.ToString() + " / " + totalUserQuestions.ToString();
        SubmitButton.SetActive (false);
    }
    private bool searchShadow (GameObject shadow) {
        foreach (AtomsGenerated a in Atoms) {
            if (a.shadowSphere.name == shadow.name) return true;
        }
        return false;
    }
    private bool searchAtoms (GameObject atom) {
        foreach (AtomsGenerated a in Atoms) {
            if (a.atomSphere.name == atom.name) return true;
        }
        return false;
    }
    public void addCount (GameObject shadow, GameObject atom, bool correct) {
        AtomsGenerated a = new AtomsGenerated (shadow, atom, correct);
        Atoms.Add (a);
        isAtomSpawned = false;
        atomSpawned = null;
    }
    public void subCount(GameObject atom) {
        foreach (AtomsGenerated a in Atoms) {
            if (a.atomSphere.name == atom.name) {
                isAtomSpawned = true;
                atomSpawned = a.atomSphere;
                a.shadowSphere.SetActive (true);
                Atoms.Remove (a);
                break;
            }
        }
    }
    public void evaluate () {
        int count = 0;
        foreach (AtomsGenerated a in Atoms) {
            if (a.correct) count++;
        }
        switch (currentQIndex) {
            case 0: if (count == 8) Score += 1; break;
            case 1: if (count == 9) Score += 1; break;
            case 2: if (count == 14) Score += 1; break;
            case 3: if (count == 27) Score += 1; break; // salt
            case 4: if (count == 18) Score += 1; break;
            case 5: if (count == 18) Score += 1; break;
            case 6: if (count == 9) Score += 1; break;
        }
    }
    public void setParent (GameObject g) {
        //Debug.Log ("curremtQIndex=" + currentQIndex.ToString());
        GameObject parent = Lattice[currentQIndex];
        Transform child = parent.transform.GetChild(0);
        //Debug.Log (child.gameObject.name);
        g.transform.parent = child;
    }
}
