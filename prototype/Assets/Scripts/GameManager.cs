using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class GameManager : MonoBehaviour
{

    [SerializeField] private string URL;
    public static GameManager inst;
    public int coins;
    //public int coins = 0;
    public Text coinText;
    public Text timeText;
    public Text goalText;
    public GameOverScreen gameOverScreen;
    public WinningScreen winningScreen;
    public bool won;
    public DateTime sessionid;

    PlayerMovement playerMovement;
    //public SortedDictionary<string, Ingredient> ingredientsList;

    public void IncrementCoinCount()
    {
        ScoreTracker.coins++;
        coins = ScoreTracker.coins;
        coinText.text = "Coins: " + ScoreTracker.coins;
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
        foreach (KeyValuePair<string, Ingredient> pair in ScoreTracker.ingredientsList)
        {
            goal += " " + pair.Key.ToString() + " (" + pair.Value.currentCount + "/" + pair.Value.requiredCount + ")";
        }

        return goal;
    }

    private void Awake()
    {
        inst = this;
        sessionid = System.DateTime.Now;
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + ScoreTracker.coins;
        goalText.text = "Goal :" + goalProgress();
        won = false;
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (won)
        {
            ScoreTracker.timeRemain = 0;
            playerMovement.stayStill = true;
        }
        else if (ScoreTracker.timeRemain >= 0 && checkIngredientsGoal())
        {
            if (!won)
            {
                winningScreen.Setup(ScoreTracker.originalTime - ScoreTracker.timeRemain);
                won = true;
            }
        }

        if (ScoreTracker.timeRemain > 0)
        {
            ScoreTracker.timeRemain -= Time.deltaTime;
            timeText.text = "Time Remaining: " + ScoreTracker.timeRemain.ToString("0") + " Sec";

            /* testing
            if (timeRemain < 110 && !testIngredient)
            {
                testIngredient = true;
                increaseIngredient("Broccoli");
                increaseIngredient("Onion");
                increaseIngredient("Chicken");
            }
            */
            
        }
        else
        {
            gameOverScreen.Setup();
            ScoreTracker.timeRemain = -1;
            playerMovement.stayStill = true;
            //Invoke("Restart", 1);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Send(String deathtype){
        StartCoroutine(Post(sessionid.ToString(), deathtype.ToString(), coins.ToString()));
        
    }

    private IEnumerator Post(string sessionid, string deathtype, string numcoins){ 

        WWWForm form = new WWWForm();
        form.AddField("entry.1946343437", sessionid);    
        form.AddField("entry.1371321124", deathtype); 
        form.AddField("entry.1055635473", numcoins);
        


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
