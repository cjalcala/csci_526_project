using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class SanctumQuiz : MonoBehaviour
{
    PlayerMovement PlayerMovement;
    GameManager gameManager;
    [SerializeField] private string URL;
    [SerializeField] private AudioSource sanctum_entry_sound;
    public List<QuizQA> questionAnswers;
    public GameObject[] options;
    public int currQuestion;

    public GameObject QuizPanel;
    public GameObject BPanel;

    public Text questionText;
    public Text coin;

    public int numCoins;
    public static int tempCoinvalue = 100;

    public Text sanctumCoins;

    public Image TimeSlider;
    public Text timeText;

    public QuizQA quizQuestion;
    public static String hint;
    public static bool notCollected = false;
    //public static int dish = 0;

    public Text bagText;
    public float bagTime = 1.5f;

    //public Text coinText;


    public GameObject LoseScreen;

    private void Start()
    {

        PlayerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        //coin = GameObject.Find("CoinText").GetComponent<Text>();
        //numCoins = tempCoinvalue;
        //coin.text = "Coins : " + numCoins.ToString();
        sanctum_entry_sound.Play();

        if (TutorialManager.tutorialActive)
        {
            sanctumCoins.text = ": " + TutorialGameManager.tutCoinCnt.ToString();
            //bagText.text = "Sorry, You have no hints!";
            // GoalScreen.coinSanctumImg.sprite = Resources.Load<Sprite>("Sprites/" + coin.name);
        }
        else
        {
            sanctumCoins.text = ": " + GameTracker.coins.ToString();
            //  GoalScreen.coinSanctumImg.sprite = Resources.Load<Sprite>("Sprites/" + coin.name);
        }

        Debug.Log("Sanctum " + GameTracker.timeRemain);
        //Debug.Log(TutorialManager.tutorialActive);
        BPanel.SetActive(false);
        questionGenerator();
    }

    public void retry()
    {
        // TutorialGameManager.tutCoinCnt -= 2;
        // GameTracker.coins -= 2;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        QuizPanel.SetActive(true);
        BPanel.SetActive(false);
        Button[] buttons = QuizPanel.GetComponentsInChildren<Button>();
        for (int b = 0; b < 4; b++)
        {
            buttons[b].enabled = true;
        }

        if(TutorialManager.tutorialActive)
        {
            TutorialGameManager.tutCoinCnt -= 2;

            if(TutorialGameManager.tutCoinCnt >= 0)
            {
                sanctumCoins.text = ": " + TutorialGameManager.tutCoinCnt.ToString();
            }
            else
            {
                TutorialGameManager.tutCoinCnt = 0;
                sanctumCoins.text = ": " + TutorialGameManager.tutCoinCnt.ToString();
            }
            
        }
        else
        {
            // GameTracker.coins -= 2;
            gameManager.changeCoinAmount(-2);
            if(GameTracker.coins >= 0)
            {
                sanctumCoins.text = ": " + GameTracker.coins.ToString();
            }
            else
            {
                GameTracker.coins = 0;
                sanctumCoins.text = ": " + GameTracker.coins.ToString();
            }
        }

    }

    void gameOver()
    {
        QuizPanel.SetActive(false);
        BPanel.SetActive(true);

        coin.text = "Coins : " + GameTracker.coins.ToString();

    }

    public void correct()
    {

        Button[] buttons = QuizPanel.GetComponentsInChildren<Button>();
        for (int b = 0; b < 4; b++)
        {
            buttons[b].enabled = false;
        }

        // Send(quizQuestion.question, 1, 0);
        if (TutorialManager.tutorialActive)
        {
            Invoke("LoadTutorialComplete", 1.5f);

        }
        else
        {

            // GameTracker.coins+=15;
            //GameTracker.increaseIngredient(quizIngredient);//use map to find the ingredient string /change increaseIngredient param to index
            //dish += 1;

            if (GameTracker.ingred1 >= 1 && GameTracker.ingred2 >= 1 && GameTracker.ingred3 >= 1)
            {
                //dish = dish + Math.Min(GameTracker.ingred1, Math.Min(GameTracker.ingred2, GameTracker.ingred3));
                //GameTracker.dish = GameTracker.dish + Math.Min(GameTracker.ingred1, Math.Min(GameTracker.ingred2, GameTracker.ingred3));
                GameTracker.dish = GameTracker.dish + 1;

               // int minCount = Math.Min(GameTracker.ingred1, Math.Min(GameTracker.ingred2, GameTracker.ingred3));

                //GameTracker.coins += (GameTracker.recipe.earning * Math.Min(GameTracker.ingred1, Math.Min(GameTracker.ingred2, GameTracker.ingred3)));

                GameTracker.ingred1 = Math.Max(0, GameTracker.ingred1 - 1);
                GameTracker.ingred2 = Math.Max(0, GameTracker.ingred2 - 1);
                GameTracker.ingred3 = Math.Max(0, GameTracker.ingred3 - 1);

            }
            // GameTracker.LoadScenes();

            Invoke("UnloadSanctum", 1.5f);
        }
    }

    public void UnloadSanctum()
    {
        GameTracker.sanctumImmunity = true;
        PlayerMovement.speed = 8;
        PlayerMovement.horizontalMultiplier = 0.8f;
        PlayerMovement.jumpForce = 750f;
        SceneManager.UnloadScene("Sanctum");
        
    }

    public void LoadTutorialComplete()
    {
        SceneManager.LoadScene("TutorialComplete");
    }

    public void wrong()
    {

        Button[] buttons = QuizPanel.GetComponentsInChildren<Button>();
        for (int b = 0; b < 4; b++)
        {
            buttons[b].enabled = false;
        }


        if (TutorialManager.tutorialActive)
        {
            if (TutorialGameManager.tutCoinCnt < 2)
            {
                //Invoke("restartTutorial", 2.0f);
                notCollected = true;
                LoseScreen.SetActive(true);


            }
            else
            {
                notCollected = false;
                Invoke("reloadSanctum", 1.5f);

            }
        }
        else
        {
            notCollected = true;
            continueGame();

            // Send(quizQuestion.question, 0, 1);

            // if (GameTracker.coins < 2)
            // {
            //     notCollected = true;
            //     continueGame();
            // }
            // else
            // {
            //     Invoke("gameOver", 2.0f);
            // }
        }
    }


    public void restartTutorial()
    {

        SceneManager.LoadScene("TutorialGame");
    }

    void reloadSanctum()
    {
        //TutorialGameManager.tutCoinCnt -= 2;
        //SceneManager.LoadScene("Sanctum");
        QuizPanel.SetActive(false);
        BPanel.SetActive(true);
        if (TutorialManager.tutorialActive)
        {
            coin.text = "Coins : " + TutorialGameManager.tutCoinCnt.ToString();
        }
        Button[] buttons = BPanel.GetComponentsInChildren<Button>();
        buttons[1].gameObject.SetActive(false);
    }


    public void continueGame()
    {
        // GameTracker.LoadScenes();
        Invoke("UnloadSanctum", 1.5f);
        
    }

    void setQnA()
    {
        hint = quizQuestion.hint;
        questionText.text = quizQuestion.question;
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = quizQuestion.answers[i];
            options[i].GetComponent<AnswerScript>().correctIdx = quizQuestion.correctAnswer;

            if (quizQuestion.correctAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
        
    }

    void questionGenerator()
    {
        if (TutorialManager.tutorialActive)
        {
            quizQuestion = TutorialManager.questionGenerator.getQuestion(1);
            
        }
        else
        {
            quizQuestion = GameTracker.questionGenerator.getQuestion(GameTracker.level);
            
        }


        if (quizQuestion != null)
        {
            setQnA();
        }
        else

        {
            Debug.Log("Out of questions");
            gameOver();
        }
    }


    public void Send(string question_id, int c, int w)
    {
        StartCoroutine(Post(question_id, c.ToString(), w.ToString()));

    }

    private IEnumerator Post(string question_id, string c, string w)
    {

        WWWForm form = new WWWForm();
        form.AddField("entry.1035881353", question_id);
        form.AddField("entry.1651523432", c);
        form.AddField("entry.281241967", w);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
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

    void Update()
    {
        if (!TutorialManager.tutorialActive)
        {
            if (GameTracker.timeRemain > 0)
            {
                //GameTracker.timeRemain -= Time.deltaTime;
                TimeSlider.fillAmount = GameTracker.timeRemain / GameTracker.originalTime;
                timeText.text = ": " + GameTracker.timeRemain.ToString("0") + "";

                int forwardSeconds = (int)GameTracker.originalTime - Convert.ToInt32(Math.Truncate(GameTracker.timeRemain));

                if ((forwardSeconds == GameTracker.timeFlag) && (GameTracker.sentAnalytics == false))
                {
                    GameTracker.coinString = GameTracker.coinString + GameTracker.coins.ToString() + ",";
                    GameTracker.timeFlag++;
                    //Debug.Log(GameTracker.coinString);
                }
            }
            else
            {
                // GameTracker.LoadScenes();
                Invoke("UnloadSanctum", 1.5f);
            }
        }
        else
        {
            if (TutorialGameManager.time > 0)
            {
                TutorialGameManager.time -= Time.deltaTime;
                TimeSlider.fillAmount = TutorialGameManager.time / 90;
                timeText.text = ": " + TutorialGameManager.time.ToString("0") + "";
            }
            else
            {
                SceneManager.LoadScene("TutorialGame");
            }
        }
    }


    public void exitTutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("WelcomeScreen");
    }
}
