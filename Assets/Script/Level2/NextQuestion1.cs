using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class NextQuestion1 : MonoBehaviour
{
    public Toggle Toggle1;
    public Toggle Toggle2;
    public Toggle Toggle3;
    public Toggle Toggle4;

    public GameObject question;
    private Assessment1 a1;
    private void Start()
    {
        a1 = question.GetComponent<Assessment1>();
    }

    public void buttonNextPressed() {
        int qno = a1.bookKeepQuestions[a1.currentQIndex-1];
        int p=0;
        int userAnswer = 0;
        if (Toggle1.isOn) userAnswer = 0;
        if (Toggle2.isOn) userAnswer = 1;
        if (Toggle3.isOn) userAnswer = 2;
        if (Toggle4.isOn) userAnswer = 3;

        int correctAnswer = Globals.q1[qno].correctAnswer;
        //Debug.Log (correctAnswer);
        //Debug.Log (userAnswer);
        if (correctAnswer == userAnswer) p = 1;
        else p = 0;
        a1.Score = a1.Score + p;
        a1.showQuestion();
    }

}
