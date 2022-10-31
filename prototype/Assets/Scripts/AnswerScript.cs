using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public SanctumQuiz sanctumQuiz;

    public int correctIdx;

    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Button>().image.color = Color.green;
            isCorrect = false;
            //Debug.Log("Correct Answer");
            sanctumQuiz.correct();
        }
        else
        {
            GetComponent<Button>().image.color = Color.red;
            if (GameTracker.coins < 10)
            {
                sanctumQuiz.options[correctIdx].GetComponent<Button>().image.color = Color.green;
            }
            //Debug.Log("Incorrect Answer");
            sanctumQuiz.wrong();
        }
    }

}
