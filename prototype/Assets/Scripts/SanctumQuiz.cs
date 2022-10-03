using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class SanctumQuiz : MonoBehaviour
{
    [SerializeField] private string URL;
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

    public Text sanctumCoins;

    private void Start()
    {
        //coin = GameObject.Find("CoinText").GetComponent<Text>();
        //numCoins = tempCoinvalue;
        //coin.text = "Coins : " + numCoins.ToString();
        if(TutorialManager.tutorialActive)
        {
            TutorialGameManager.tutCoinCnt-=2;
            sanctumCoins.text = "Coins : " + TutorialGameManager.tutCoinCnt.ToString();
        }
        else
        {
            sanctumCoins.text = "Coins : " + ScoreTracker.coins.ToString();
        }
        



        Debug.Log(TutorialManager.tutorialActive);
        totalQuestions = questionAnswers.Count;
        BPanel.SetActive(false);
        questionGenerator(); 
    }

    public void retry()
    {
        ScoreTracker.coins -= 10;
        //coin.text = numCoins.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void gameOver()
    {
        QuizPanel.SetActive(false);
        BPanel.SetActive(true);
        coin.text = "Coins : " + ScoreTracker.coins.ToString();
    }

    public void correct()
    {

        if (currQuestion != questionAnswers.Count-1) {
           QuizQA last = questionAnswers[questionAnswers.Count-1];
           questionAnswers[currQuestion] = last;
        } 
        questionAnswers.RemoveAt(questionAnswers.Count-1);
        

        Send(currQuestion, 1, 0);
        //gameOver();
        
        // if(ScoreTracker.uncompletedIngredients().Count > 0)
        // {
        //     List<string> keyList = ScoreTracker.uncompletedIngredients();
        //     int randValue = Random.Range(0, keyList.Count);
        //     ScoreTracker.increaseIngredient(keyList[randValue]);
        // }
        if(TutorialManager.tutorialActive)
        {
            Invoke("LoadTutorialComplete", 1.5f);
        }
        else
        {
            string Ingredient = PlayerPrefs.GetString("IngredientID");// Change to index later
            ScoreTracker.increaseIngredient(Ingredient);//use map to find the ingredient string /change increaseIngredient param to index
            SceneManager.LoadScene("Game");
        }
        //questionGenerator();


    }

    public void LoadTutorialComplete()
    {
        SceneManager.LoadScene("TutorialComplete");
    }

    public void wrong()
    {
        //questionAnswers.RemoveAt(currQuestion);
        
        //questionAnswers.RemoveAt(currQuestion);
        if(TutorialManager.tutorialActive)
        {
            if(TutorialGameManager.tutCoinCnt < 10)
            {
                Invoke("restartTutorial", 2.0f);
            }
            else
            {
                Invoke("reloadSanctum", 1.5f);
            }
        }else {

            Send(currQuestion, 0, 1);

            if (ScoreTracker.coins < 10)
            {
                continueGame();
            }
            else {
                Invoke("gameOver", 2.0f);
            }

        }
        
        
        //questionGenerator();
    }

    void restartTutorial()
    {
        SceneManager.LoadScene("TutorialGame");
    }

    void reloadSanctum()
    {
        TutorialGameManager.tutCoinCnt-=8;
        SceneManager.LoadScene("Sanctum");
    }
    

    public void continueGame()
    {
        SceneManager.LoadScene("Game");   
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


    public void Send(int question_id, int c, int w){
        StartCoroutine(Post(question_id.ToString(), c.ToString(), w.ToString()));
        
    }

    private IEnumerator Post(string question_id, string c, string w){ 

        WWWForm form = new WWWForm();
        form.AddField("entry.1035881353", question_id);    
        form.AddField("entry.1651523432", c); 
        form.AddField("entry.281241967", w);
        
        


        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))    {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success) 
                {            
                    Debug.Log(www.error);        
                }       
            else       
                {           
                      Debug.Log("Form upload complete!");        
                }    

            www.Dispose();
        }

    }

}
