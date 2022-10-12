using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


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

    public QuizQA quizQuestion;
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
            sanctumCoins.text = "Coins : " + ScoreTracker.coins.ToString();
        }


        Debug.Log(TutorialManager.tutorialActive);
        BPanel.SetActive(false);
        questionGenerator(0.7, 0.3, 0);
    }

    public void retry() {
        ScoreTracker.coins -= 10;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        QuizPanel.SetActive(true);
        BPanel.SetActive(false);
        Button[] buttons = QuizPanel.GetComponentsInChildren<Button>();
        for(int b=0; b<4; b++)
        {
            buttons[b].enabled = true;
        }
        sanctumCoins.text = "Coins : " + ScoreTracker.coins.ToString();
    }

    void gameOver() {
        QuizPanel.SetActive(false);
        BPanel.SetActive(true);

        coin.text = "Coins : " + ScoreTracker.coins.ToString();
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
            string Ingredient = PlayerPrefs.GetString("IngredientID");// Change to index later
            ScoreTracker.increaseIngredient(Ingredient);//use map to find the ingredient string /change increaseIngredient param to index
            SceneManager.LoadScene("Game");
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

            if (ScoreTracker.coins < 10) {
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
        SceneManager.LoadScene("Game");
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

    void questionGenerator(double easyRate, double mediumRate, double hardRate) {
        if (TutorialManager.tutorialActive) {
            quizQuestion = TutorialManager.questionGenerator.getQuestion(easyRate, mediumRate, hardRate);
        }
        else {
            quizQuestion = GameManager.questionGenerator.getQuestion(easyRate, mediumRate, hardRate);
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
}
