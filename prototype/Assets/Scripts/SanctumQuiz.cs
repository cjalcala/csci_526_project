using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SanctumQuiz : MonoBehaviour
{
    public List<QuizQA> questionAnswers;
    public GameObject[] options;
    public int currQuestion;

    public GameObject QuizPanel;
    public GameObject BPanel;
    
    public Text questionText;
    public Text coin;

    int totalQuestions = 0;
    public int numCoins;
    public static int tempCoinvalue = 100;

    private void Start()
    {
        //coin = GameObject.Find("CoinText").GetComponent<Text>();
        numCoins = tempCoinvalue;
        //coin.text = "Coins : " + numCoins.ToString();
        totalQuestions = questionAnswers.Count;
        BPanel.SetActive(false);
        questionGenerator(); 
    }

    public void retry()
    {
        tempCoinvalue -= 10;
        //coin.text = numCoins.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void gameOver()
    {
        QuizPanel.SetActive(false);
        BPanel.SetActive(true);
        coin.text = "Coins : " + numCoins.ToString();
    }

    public void correct()
    {
        questionAnswers.RemoveAt(currQuestion);
        //gameOver();
        SceneManager.LoadScene("SampleScene");
        //questionGenerator();
    }

    public void wrong()
    {
        //questionAnswers.RemoveAt(currQuestion);
        Invoke("gameOver", 2.0f);
        //questionGenerator();
    }

    public void continueGame()
    {
     SceneManager.LoadScene("SampleScene");   
    }

    void setAnswers()
    {
        for(int i=0; i<options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questionAnswers[currQuestion].answers[i];

            if(questionAnswers[currQuestion].correctAnswer == i+1)
            {
                 options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void questionGenerator()
    {
        if(questionAnswers.Count > 0)
        {
            currQuestion = Random.Range(0, questionAnswers.Count);

            questionText.text = questionAnswers[currQuestion].question;

            setAnswers();
        } 
        else
        {
            //Debug.Log("Out of questions");
            gameOver(); 
        }
    }

}
