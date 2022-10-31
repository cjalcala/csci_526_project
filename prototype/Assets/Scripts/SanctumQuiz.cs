using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class SanctumQuiz : MonoBehaviour {
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
    string quizIngredient;// Change to index later
    private void Start() {
        //coin = GameObject.Find("CoinText").GetComponent<Text>();
        //numCoins = tempCoinvalue;
        //coin.text = "Coins : " + numCoins.ToString();
        sanctum_entry_sound.Play();

        if(TutorialManager.tutorialActive)
        {
            TutorialGameManager.tutCoinCnt-=2;
            sanctumCoins.text = "Coins : " + TutorialGameManager.tutCoinCnt.ToString();
        }
        else {
            sanctumCoins.text = "Coins : " + GameTracker.coins.ToString();
        }

        Debug.Log("Sanctum "+GameTracker.timeRemain);
        //Debug.Log(TutorialManager.tutorialActive);
        BPanel.SetActive(false);
        quizIngredient = PlayerPrefs.GetString("IngredientID");// Change to index later
        questionGenerator(0.7, 0.3, 0);
        //fiftyFifty();
    }

    public void retry() {
        GameTracker.coins -= 10;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        QuizPanel.SetActive(true);
        BPanel.SetActive(false);
        Button[] buttons = QuizPanel.GetComponentsInChildren<Button>();
        for(int b=0; b<4; b++)
        {
            buttons[b].enabled = true;
        }
        sanctumCoins.text = "Coins : " + GameTracker.coins.ToString();
    }

    void gameOver() {
        QuizPanel.SetActive(false);
        BPanel.SetActive(true);

        coin.text = "Coins : " + GameTracker.coins.ToString();
    }

    public void correct() {

        Button[] buttons = QuizPanel.GetComponentsInChildren<Button>();
        for(int b=0; b<4; b++)
        {
            buttons[b].enabled = false;
        }
        
       Send(quizQuestion.question, 1, 0);
        if (TutorialManager.tutorialActive) {
            Invoke("LoadTutorialComplete", 1.5f);
        }
        else {
            GameTracker.increaseIngredient(quizIngredient);//use map to find the ingredient string /change increaseIngredient param to index
            GameTracker.LoadScenes();
        }
    }

    public void LoadTutorialComplete() {
        SceneManager.LoadScene("TutorialComplete");
    }

    public void wrong() {

        Button[] buttons = QuizPanel.GetComponentsInChildren<Button>();
        for(int b=0; b<4; b++)
        {
            buttons[b].enabled = false;
        }

        if (TutorialManager.tutorialActive) {
            if (TutorialGameManager.tutCoinCnt < 10) {
                Invoke("restartTutorial", 2.0f);
            }
            else {
                Invoke("reloadSanctum", 1.5f);

            }
        }
        else {

            Send(quizQuestion.question, 0, 1);

            if (GameTracker.coins < 10) {
                continueGame();
            }
            else {
                Invoke("gameOver", 2.0f);
            }
        }
    }

    void restartTutorial() {
        SceneManager.LoadScene("TutorialGame");
    }

    void reloadSanctum() {
        TutorialGameManager.tutCoinCnt -= 8;
        //SceneManager.LoadScene("Sanctum");
        QuizPanel.SetActive(false);
        BPanel.SetActive(true);
        Button[] buttons = BPanel.GetComponentsInChildren<Button>();
        buttons[1].gameObject.SetActive(false);
    }


    public void continueGame() {
        GameTracker.LoadScenes();
    }

    void setQnA() {
        questionText.text = quizQuestion.question;
        for (int i = 0; i < options.Length; i++) {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = quizQuestion.answers[i];

            if (quizQuestion.correctAnswer == i) {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    /*void fiftyFifty() {
        eliminateWrongAnswers(2);
    }

    void eliminateWrongAnswers(int countToEliminate) {
        Button[] buttons = QuizPanel.GetComponentsInChildren<Button>();
        if (countToEliminate >= buttons.Length - 1) {
            Debug.Log("Eliminating too many answers,only correct or 0 answer left");
        }
        int correctAns = quizQuestion.correctAnswer;
        int index = 0;
        while (index < countToEliminate) {
            System.Random rnd = new System.Random();
            int num = rnd.Next(5);
            if (num != correctAns) {
                index++;
                buttons[num].enabled = false;
                buttons[num].image.color = Color.red;
            }
        }
    }*/

    void questionGenerator(double easyRate, double mediumRate, double hardRate) {
        if (TutorialManager.tutorialActive) {
            quizQuestion = TutorialManager.questionGenerator.getQuestion(easyRate, mediumRate, hardRate);
            var qT = TutorialManager.questionGenerator.getIngredientQuestion(quizIngredient);
        }
        else {
            quizQuestion = GameTracker.questionGenerator.getQuestion(easyRate, mediumRate, hardRate);
            var qT = GameTracker.questionGenerator.getIngredientQuestion(quizIngredient);
        }

        if (quizQuestion != null) {
            setQnA();
        }
        else {
            Debug.Log("Out of questions");
            gameOver();
        }
    }


    public void Send(string question_id, int c, int w) {
        StartCoroutine(Post(question_id, c.ToString(), w.ToString()));

    }

    private IEnumerator Post(string question_id, string c, string w) {

        WWWForm form = new WWWForm();
        form.AddField("entry.1035881353", question_id);
        form.AddField("entry.1651523432", c);
        form.AddField("entry.281241967", w);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else {
                Debug.Log("Form upload complete!");
            }

            www.Dispose();
        }

    }

    void Update()
    {
        if(!TutorialManager.tutorialActive)
        {
            if (GameTracker.timeRemain > 0)
            {
                GameTracker.timeRemain -= Time.deltaTime;
                TimeSlider.fillAmount = GameTracker.timeRemain/GameTracker.originalTime;
                timeText.text = ": " + GameTracker.timeRemain.ToString("0") + " Sec";

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
                GameTracker.LoadScenes();
            }
        }
        else
        {
            if (TutorialGameManager.time > 0)
            {
                TutorialGameManager.time -= Time.deltaTime;
                TimeSlider.fillAmount = TutorialGameManager.time/90;
                timeText.text = ": " + TutorialGameManager.time.ToString("0") + " Sec";
            }
            else
            {
                SceneManager.LoadScene("TutorialGame");
            }
        }
    }
}
