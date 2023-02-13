using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class NextQuestion2 : MonoBehaviour
{
    public GameObject question;
    public GameObject[] selector;
    private Assessment2 a1;
    private void Start()
    {
        a1 = question.GetComponent<Assessment2>();
    }

    public void buttonNextPressed() {
        int qno = a1.bookKeepQuestions[a1.currentQIndex-1];
        int p=0;
        int userAnswer = 0;
        for (int i=0; i<selector.Length; i++) 
            if (selector[i].GetComponent<MeshRenderer>().enabled) userAnswer = i;

        int correctAnswer = Globals.q2[qno].correctAnswer;
        
        if (correctAnswer == userAnswer) p = 1;
        else p = 0;
        a1.Score = a1.Score + p;
        a1.showQuestion();
    }

}
