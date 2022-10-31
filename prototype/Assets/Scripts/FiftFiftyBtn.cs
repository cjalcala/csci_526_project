using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiftFiftyBtn : MonoBehaviour
{
    public SanctumQuiz sanctumQuiz;
    public GameObject QuizPanel;
    public Button btn;
    public void fiftyFifty() {
        eliminateWrongAnswers(2);
        btn.gameObject.SetActive(false);
        
    }

    public void eliminateWrongAnswers(int countToEliminate) {
        Button[] buttons = QuizPanel.GetComponentsInChildren<Button>();
        if (countToEliminate >= buttons.Length - 1) {
            Debug.Log("Eliminating too many answers,only correct or 0 answer left");
        }
        int correctAns = sanctumQuiz.quizQuestion.correctAnswer;
        ArrayList wrongAnsList = new ArrayList();
        for (int i = 0; i < 4; i++) {
            if (i != correctAns) {
                wrongAnsList.Add(i);
            }      
        }
        int count = 0;
        while (count < countToEliminate) {
            System.Random rnd = new System.Random();
            int num = rnd.Next(wrongAnsList.Count);
            int index = (int)wrongAnsList[num];
            buttons[index].enabled = false;
            buttons[index].image.color = Color.red;
            wrongAnsList.RemoveAt(num);
            count++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameTracker.fiftyFiftyCount == 0) {
            btn.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
