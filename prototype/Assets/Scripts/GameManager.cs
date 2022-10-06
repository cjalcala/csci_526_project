using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class GameManager : MonoBehaviour
{


    [SerializeField] private AudioSource coin_collected_sound;
    [SerializeField] private string URL;
    [SerializeField] private string URLforLevel;
    public string deathUrl = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSfuhQ1nIxbyLGl3O0aXOQ1RGkX3M_9UU1UV1WJy6daNP6AEpw/formResponse";
    public string[] deathFields = { "entry.2014458776", "entry.1123890612", "entry.462759076", "entry.1893677595", "entry.811987276" };
    public static int deathFieldsCount = 5;
    public string[] deathValues = new string[deathFieldsCount];
    public bool hasHitObstacle = false;

    public static GameManager inst;
    public int coins;
    public Text coinText;
    public Text timeText;
    public Text goalText;
    public GameOverScreen gameOverScreen;
    public WinningScreen winningScreen;
    public bool won;
    public Image[] ingredientIcon;
    public DateTime sessionid;
    public int level = 1;
    public int level_flag = 0;
    public long sessionNum;
    public DateTime timestamp;
    public int flag = 0;

    public int tileCount = 0;

    public Text insufficientPopup;
    public float timeDisplay = 1.5f;

    PlayerMovement playerMovement;
    //public SortedDictionary<string, Ingredient> ingredientsList;

    public void IncrementCoinCount()
    {
        coin_collected_sound.Play();
        ScoreTracker.coins++;
        coins = ScoreTracker.coins;
        coinText.text = ": " + ScoreTracker.coins;
    }

    public void increaseIngredient(string name)
    {
        ScoreTracker.ingredientsList[name].currentCount++;
        goalText.text = "Goal :" + goalProgress();
    }

    public bool checkIngredientsGoal()
    {
        bool goalReached = true;
        foreach (KeyValuePair<string, Ingredient> pair in ScoreTracker.ingredientsList)
        {
            goalReached = goalReached && pair.Value.currentCount >= pair.Value.requiredCount;
        }

        return goalReached;
    }

    public string goalProgress()
    {
        string goal = "";
        int index = 0;
        foreach (KeyValuePair<string, Ingredient> pair in ScoreTracker.ingredientsList)
        {
            goal += "           x" + pair.Value.currentCount + "/" + pair.Value.requiredCount;
            ingredientIcon[index].sprite = Resources.Load<Sprite>("Sprites/" + pair.Key.ToString());
            index++;
        }

        return goal;
    }

    private void Awake()
    {
        inst = this;
        sessionid = System.DateTime.Now;
        sessionNum = DateTime.Now.Ticks;
        timestamp = System.DateTime.Now;

    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = ": " + ScoreTracker.coins;
        goalText.text = "Goal :" + goalProgress();
        won = false;
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        TutorialManager.tutorialActive = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (won)
        {
            ScoreTracker.timeRemain = 0;
            playerMovement.stayStill = true;
            level_flag++;
            if (level_flag == 1)
            {
                NewSend("true");
            }

        }
        else if (ScoreTracker.timeRemain >= 0 && checkIngredientsGoal())
        {
            if (!won)
            {
                winningScreen.Setup(ScoreTracker.originalTime - ScoreTracker.timeRemain);
                won = true;
                flag++;
                if (flag == 1)
                {
                    deathValues[0] = GameManager.inst.timestamp.ToString();
                    deathValues[1] = GameManager.inst.sessionNum.ToString();
                    deathValues[2] = "won";
                    deathValues[3] = "";
                    deathValues[4] = (120 - ScoreTracker.timeRemain).ToString("0");
                    //TODO: Get the value of 120 above dynamically
                    Send("deathTracker");
                }
            }
        }

        if (ScoreTracker.timeRemain > 0)
        {
            ScoreTracker.timeRemain -= Time.deltaTime;
            timeText.text = ": " + ScoreTracker.timeRemain.ToString("0") + " Sec";

        }
        else
        {
            level_flag++;
            if (level_flag == 1)
            {
                NewSend("false");
            }

            flag++;
            if ((flag == 1) && (hasHitObstacle == false))
            {
                deathValues[0] = GameManager.inst.timestamp.ToString();
                deathValues[1] = GameManager.inst.sessionNum.ToString();
                deathValues[2] = "lost";
                deathValues[3] = "time";
                deathValues[4] = 120.ToString();
                //TODO: Get the value of 120 above dynamically
                Send("deathTracker");
            }

            gameOverScreen.Setup();
            ScoreTracker.timeRemain = -1;
            playerMovement.stayStill = true;
            //Invoke("Restart", 1);
        }
        if (ScoreTracker.insufficientCoins && timeDisplay >= 0)
        {
          insufficientPopup.text = "You have insufficient coins!";
          timeDisplay -= Time.deltaTime;
        }

        if (ScoreTracker.insufficientCoins && timeDisplay < 0)
        {
          insufficientPopup.text = "";
          ScoreTracker.insufficientCoins = false;
          timeDisplay = 1.5f;
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NewSend(String level_complete)
    {
        StartCoroutine(Post(level.ToString(), level_complete.ToString()));

    }

    //public void Send(string deathtype){
    public void Send(string analyticsName)
    {
        //StartCoroutine(Post(sessionid.ToString(), deathtype.ToString(), coins.ToString()));
        StartCoroutine(PostAnalytics(analyticsName));

    }

    private IEnumerator Post(string level, string level_complete)
    {

        // WWWForm form = new WWWForm();
        // form.AddField("entry.1946343437", sessionid);    
        // form.AddField("entry.1371321124", deathtype); 
        // form.AddField("entry.1055635473", numcoins);



        // using (UnityWebRequest www = UnityWebRequest.Post(URL, form))    {
        //     yield return www.SendWebRequest();
        //     if (www.result != UnityWebRequest.Result.Success) 
        //         {            
        //             Debug.Log(www.error);        
        //         }       
        //     else       
        //         {           
        //               Debug.Log("Form upload complete!");        
        //         }    

        //     www.Dispose();
        // }



        WWWForm form = new WWWForm();
        form.AddField("entry.1136704430", level);
        form.AddField("entry.1145566479", level_complete);




        using (UnityWebRequest www = UnityWebRequest.Post(URLforLevel, form))
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

    //private IEnumerator Post(string sessionid, string deathtype, string numcoins){
    private IEnumerator PostAnalytics(string analyticsName)
    {
        string URL = "";
        WWWForm form = new WWWForm();

        if (analyticsName == "deathTracker")
        {
            URL = deathUrl;
            for (int i = 0; i < deathFieldsCount; i++)
            {
                form.AddField(deathFields[i], deathValues[i]);
            }
        }

        //form.AddField("entry.2014458776", sessionid);    
        //form.AddField("entry.1123890612", deathtype); 
        //form.AddField("entry.462759076", numcoins);
        //form.AddField("entry.1893677595", sessionid);
        //form.AddField("entry.811987276", deathtype);



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
}
