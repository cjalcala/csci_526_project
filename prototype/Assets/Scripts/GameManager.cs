using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;
using System.Reflection;

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

    public string coinUrl = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSfNOKGPFcJHBhW3aqq3rpqn-OloFrCRbjF6k28ogArTugkc1g/formResponse";
    public string[] coinFields = { "entry.1262230275", "entry.1098493085" };
    public static int coinFieldsCount = 2;

    public static GameManager inst;
    public int coins;
    public Text coinText;
    public Text timeText;
    // ingredients along the path
    // // cucumber
    // public int cucumber;
    // public Text cucumberText;
    // // lemon
    // public int lemon;
    // public Text lemonText;
    // // yogurt
    // public int yogurt;
    // public Text yogurtText;
    // // tomato
    // public int tomato;
    // public Text tomatoText;
    public int ingredient1;
    public Text ingredient1Text;
    public Image ingredient1Icon;
    public int ingredient2;
    public Text ingredient2Text;
    public Image ingredient2Icon;
    public int ingredient3;
    public Text ingredient3Text;
    public Image ingredient3Icon;
    
    // reward & dish
    public Text rewardText;
    public Text dishText; 


   

    public Text fiftyFiftyText;
    //public Text goalText;
    public GameOverScreen gameOverScreen;
    public WinningScreen winningScreen;
    public bool won;
    public Image[] ingredientIcon;
    public Text[] goalText;
    public Text[] costText;
    public DateTime sessionid;
    //public int level = 1;
    public int level_flag = 0;
    public long sessionNum;
    public DateTime timestamp;
    public int flag = 0;

    public int tileCount = 0;

    public Text insufficientPopup;
    public float timeDisplay = 1.5f;

    public Text hammerOnText;
    public float hammerOnTexttimeDisplay = 1.5f;
    public Text hammerOffText;
    public float hammerOffTexttimeDisplay = 1.5f;
    public int hflag = 0;
    
    public Text fiftyFiftyPopUpText;
    public float fiftyFiftyTexttimeDisplay = 1.5f;
    public float hintTexttimeDisplay = 1.5f;

    public Text notCollectedIngredient; 
    public float notCollectedIngredienttimeDisplay = 1.5f;
    //public float collectedIngredienttimeDisplay = 1.5f;
    
    public Boolean TimePowerUp = false;

    public float TimePowerUpStart = 0;

    public Image TimeSlider;
    public Image[] hearts;
    public static int recipeCounter = 0;

    // public Text timeOnText;
    // public Text timeOffText;

    //public static QuestionGenerator questionGenerator;
    PlayerMovement playerMovement;
    //public SortedDictionary<string, Ingredient> ingredientsList;

    public  void changeCoinAmount(int num)
    {
        coin_collected_sound.Play();
        GameTracker.coins += num;
        coins = GameTracker.coins;
        coinText.text = ": " + GameTracker.coins;
    }

    // Increment Ingredient along the path
    // public void IncrementCucumberCount() 
    // {
    //     GameTracker.cucumber++;
    //     cucumber = GameTracker.cucumber;
    //     cucumberText.text = ": " + GameTracker.cucumber;
    //     changeCoinAmount(-2);
    // }
    public void IncrementIngredient1Count()
    {
        GameTracker.ingred1++;
        ingredient1 = GameTracker.ingred1;
        ingredient1Text.text = ": " + GameTracker.ingred1;
        changeCoinAmount(-2);
    }
    public void IncrementIngredient2Count()
    {
        GameTracker.ingred2++;
        ingredient2 = GameTracker.ingred2;
        ingredient2Text.text = ": " + GameTracker.ingred2;
        changeCoinAmount(-2);
    }
    public void IncrementIngredient3Count()
    {
        GameTracker.ingred3++;
        ingredient3 = GameTracker.ingred3;
        ingredient3Text.text = ": " + GameTracker.ingred3;
        changeCoinAmount(-2);
    }

    // public void IncrementLemonCount() 
    // {
    //     GameTracker.lemon++;
    //     lemon = GameTracker.lemon;
    //     lemonText.text = ": " + GameTracker.lemon;
    //     changeCoinAmount(-2);
    // }
    
    // public void IncrementYogurtCount()
    // {
    //     GameTracker.yogurt++;
    //     yogurt = GameTracker.yogurt;
    //     yogurtText.text = ": " + GameTracker.yogurt;
    //     changeCoinAmount(-2);
    // }

    // public void IncrementTomatoCount()
    // {
    //     GameTracker.tomato++;
    //     tomato = GameTracker.tomato;
    //     tomatoText.text = ": " + GameTracker.tomato;
    //     changeCoinAmount(-2);                    
    // }

    public bool CheckIngredientSet()
    {
        bool fullSet = true;
        return GameTracker.ingred1 >= 1 && GameTracker.ingred2 >= 1 && GameTracker.ingred3 >= 1;
    }


    public void IncrementFifityFiftyCount() {
        GameTracker.fiftyFiftyCount++;
        fiftyFiftyText.text = ": " + GameTracker.fiftyFiftyCount;
    }

    public void IncrementHintCount() {
        GameTracker.hintCount++;
    }

    public void increaseIngredient(string name)
    {
        GameTracker.ingredientsList[name].currentCount++;
        goalProgress();
    }

    public bool checkIngredientsGoal()
    {
        bool goalReached = true;
        foreach (KeyValuePair<string, Ingredient> pair in GameTracker.ingredientsList)
        {
            goalReached = goalReached && pair.Value.currentCount >= pair.Value.requiredCount;
        }

        return goalReached;
    }

    public void goalProgress()
    {
        string goal = "";
        int index = 0;
        foreach (KeyValuePair<string, Ingredient> pair in GameTracker.ingredientsList)
        {
            goal = "x" + pair.Value.currentCount + "/" + pair.Value.requiredCount;
            ingredientIcon[index].sprite = Resources.Load<Sprite>("Sprites/" + pair.Key.ToString());
            goalText[index].text = goal;
            index++;
        }
    }

    public void Cost()
    {
        int index = 0;
        foreach (KeyValuePair<string, Ingredient> pair in GameTracker.ingredientsList)
        {
            costText[index].text = pair.Value.cost.ToString();
            index++;
        }

    }

    private void Awake()
    {
        inst = this;
        sessionid = System.DateTime.Now;
        sessionNum = DateTime.Now.Ticks;
        timestamp = System.DateTime.Now;
        GameTracker.sentAnalytics = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = ": " + GameTracker.coins;
        fiftyFiftyText.text = ": " + GameTracker.fiftyFiftyCount;
        dishText.text =  ": " + SanctumQuiz.dish;
        
        ingredient1Text.text = ": " + GameTracker.ingred1;
        ingredient2Text.text = ": " + GameTracker.ingred2;
        ingredient3Text.text = ": " + GameTracker.ingred3;
            
        // }
        // if (GameTracker.level == 2)
        // {
        //      tomatoText.text = ": " + GameTracker.tomato;

        // }

        //goalProgress();
        //Cost();

        ingredient1Icon.sprite = Resources.Load<Sprite>("Sprites/" + GameTracker.ingredientNames[0]);
        ingredient2Icon.sprite = Resources.Load<Sprite>("Sprites/" + GameTracker.ingredientNames[1]);
        ingredient3Icon.sprite = Resources.Load<Sprite>("Sprites/" + GameTracker.ingredientNames[2]);
        
        ingredient1Icon.gameObject.SetActive(true);
        ingredient2Icon.gameObject.SetActive(true);
        ingredient3Icon.gameObject.SetActive(true);


       

        won = false;
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        TutorialManager.tutorialActive = false;
        //questionGenerator = new QuestionGenerator();
        Debug.Log("Game "+GameTracker.timeRemain);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (Input.GetKeyDown(KeyCode.P)) {
                if (PauseMenu.GameIsPaused) {
                    PauseMenu.pm.Resume();
                } else {
                    PauseMenu.pm.Pause();
                }
            }
        }

        if (TimePowerUp && Math.Abs(GameTracker.timeRemain - TimePowerUpStart) >= 2.5)
        {
            TimePowerUp = false;
            // timeOffText.text = "Timer Counter Slow Down FINISH";
            timeText.color = Color.black;
        }

        if (won)
        {
            GameTracker.timeRemain = 0;
            playerMovement.stayStill = true;
            level_flag++;
            if (level_flag == 1)
            {
                NewSend("true");
            }

        }
        else if (GameTracker.timeRemain >= 0 && checkIngredientsGoal())
        {
            if (!won)
            {
                winningScreen.Setup(GameTracker.originalTime - GameTracker.timeRemain);
                won = true;
                flag++;
                if (flag == 1)
                {
                    deathValues[0] = GameManager.inst.timestamp.ToString();
                    deathValues[1] = GameManager.inst.sessionNum.ToString();
                    deathValues[2] = "won";
                    deathValues[3] = "";
                    deathValues[4] = (GameTracker.originalTime - GameTracker.timeRemain).ToString("0");
                    Send("deathTracker");
                    Send("coinTracker");
                }
            }
        }

        if (GameTracker.timeRemain > 0)
        {
            if (TimePowerUp)
            {
                GameTracker.timeRemain -= Time.deltaTime / 2;
                TimeSlider.fillAmount = GameTracker.timeRemain/GameTracker.originalTime;
                timeText.text = ": " + GameTracker.timeRemain.ToString("0") + " Sec SLOW";
                // timeText.color = Color.red;

            }
            else
            {
                GameTracker.timeRemain -= Time.deltaTime;
                TimeSlider.fillAmount = GameTracker.timeRemain/GameTracker.originalTime;
                timeText.text = ": " + GameTracker.timeRemain.ToString("0") + " Sec";
            }

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
                deathValues[4] = GameTracker.originalTime.ToString("0");
                Send("deathTracker");
                Send("coinTracker");
            }

            gameOverScreen.Setup();
            GameTracker.timeRemain = -1;
            playerMovement.stayStill = true;
            //Invoke("Restart", 1);
        }
        if (GameTracker.insufficientCoins && timeDisplay >= 0)
        {
            insufficientPopup.text = "You have insufficient coins!";
            timeDisplay -= (TimePowerUp ? Time.deltaTime / 2 : Time.deltaTime);
            // TimePowerUp ?  timeDisplay -= Time.deltaTime/2 : timeDisplay -= Time.deltaTime/2;
        }

        if (GameTracker.insufficientCoins && timeDisplay < 0)
        {
            insufficientPopup.text = "";
            GameTracker.insufficientCoins = false;
            timeDisplay = 1.5f;
        }

     /*   if (SanctumQuiz.collected==true && collectedIngredienttimeDisplay >= 0)
            {
                

                collectedIngredient.color = Color.black;
                collectedIngredient.text = "You have sucessfully collected " + SanctumQuiz.quizIngredient;
                collectedIngredienttimeDisplay -= (Time.deltaTime/2);
            // SanctumQuiz.collected = false;
                // TimePowerUp ?  timeDisplay -= Time.deltaTime/2 : timeDisplay -= Time.deltaTime/2;
            }

        if (SanctumQuiz.collected==true && collectedIngredienttimeDisplay < 0)
            {
                collectedIngredient.text ="";
                SanctumQuiz.collected = false;
                collectedIngredienttimeDisplay = 1.5f;
            }
*/



        if (SanctumQuiz.notCollected==true && notCollectedIngredienttimeDisplay >= 0)
                {
                    notCollectedIngredient.color = Color.red;
                    notCollectedIngredient.text = "No Reward Collected!";
                    notCollectedIngredienttimeDisplay -= (Time.deltaTime/2);
    
                }

                if (SanctumQuiz.notCollected==true && notCollectedIngredienttimeDisplay < 0)
                {
                    notCollectedIngredient.text ="";
                    SanctumQuiz.notCollected = false;
                    notCollectedIngredienttimeDisplay = 1.5f;
                }

        if (Welcome.immunity)
        {
            if (GameTracker.hammerFlag == 0)
            {
                GameTracker.hammerStartTime = GameTracker.timeRemain;
                GameTracker.hammerFlag = 1;
                fiftyFiftyPopUpText.text = "Obstacle Immunity for 5 sec";
            }
            else
            {
                if (GameTracker.timeRemain <= GameTracker.hammerStartTime - 5)
                {
                    Welcome.immunity = false;
                    GameTracker.hammerFlag = 0;
                    hammerOffText.text = "Obstacle Immunity Off";
                    hflag = 1;
                }
            }
        }

        

        if (GameTracker.hammerFlag == 1)
        {
            if (hammerOnTexttimeDisplay < 0)
            {
                hammerOnText.text = "";
                hammerOnTexttimeDisplay = 1.5f;
            }
            else
            {
                hammerOnTexttimeDisplay -= Time.deltaTime;
                // hammerOnTexttimeDisplay -= (TimePowerUp ? Time.deltaTime / 2 : Time.deltaTime);
            }
        }
        //50-50 pop up text
        if (GameTracker.getFiftyFiftyPowerUp) 
        {
            GameTracker.fiftyFiftyPopUpStartTime = GameTracker.timeRemain;
            GameTracker.fiftyFiftyPopUpFlag = 1;
            fiftyFiftyPopUpText.text = "Use this power up in sanctum to eliminate 2 wrong answers";
            GameTracker.getFiftyFiftyPowerUp = false;
        }   
        if (GameTracker.fiftyFiftyPopUpFlag == 1) {
            if (fiftyFiftyTexttimeDisplay < 0) {
                fiftyFiftyPopUpText.text = "";
                    fiftyFiftyTexttimeDisplay = 1.5f;
            }
            else {
                fiftyFiftyTexttimeDisplay -= Time.deltaTime;
            }
        }
        //hint pop up text
        if (GameTracker.getHintPowerUp) {
            GameTracker.hintPopUpStartTime = GameTracker.timeRemain;
            GameTracker.hintPopUpFlag = 1;
            fiftyFiftyPopUpText.text = "Use this power up in cook stations to get hints";
            GameTracker.getHintPowerUp = false;
        }
        if (GameTracker.hintPopUpFlag == 1) {
            if (hintTexttimeDisplay < 0) {
                fiftyFiftyPopUpText.text = "";
                hintTexttimeDisplay = 1.5f;
            }
            else {
                hintTexttimeDisplay -= Time.deltaTime;
            }
        }


        if (hflag == 1)
        {
            if (hammerOffTexttimeDisplay < 0)
            {
                hammerOffText.text = "";
                hammerOffTexttimeDisplay = 1f;
            }
            else
            {
                hammerOffTexttimeDisplay -= Time.deltaTime;
                // hammerOffTexttimeDisplay -= (TimePowerUp ? Time.deltaTime / 2 : Time.deltaTime);
            }
        }


        if(GameTracker.health<5)
        {
            for(int h=GameTracker.health;h<=4;h++)
            {
                hearts[h].enabled=false;
            }
            
        }

    }

    void Restart()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NewSend(String level_complete)
    {
        StartCoroutine(Post(GameTracker.level.ToString(), level_complete.ToString()));

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

        if (analyticsName == "coinTracker")
        {
            URL = coinUrl;
            form.AddField(coinFields[0], sessionNum.ToString());
            form.AddField(coinFields[1], GameTracker.coinString);
            GameTracker.coinString = "";
            GameTracker.sentAnalytics = true;
            GameTracker.timeFlag = 1;
        }

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
