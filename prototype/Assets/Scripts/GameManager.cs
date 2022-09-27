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
    [SerializeField] private string URLforLevel;

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

    PlayerMovement playerMovement;
    //public SortedDictionary<string, Ingredient> ingredientsList;

    public void IncrementCoinCount()
    {
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
            if (level_flag == 1){
                NewSend("true");
            }
            
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
            timeText.text = ": " + ScoreTracker.timeRemain.ToString("0") + " Sec";
            
        }
        else
        {
            level_flag++;
            if (level_flag == 1){
                NewSend("false");
            }
            
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

    public void NewSend(String level_complete){
        StartCoroutine(Post(level.ToString(), level_complete.ToString()));
        
    }


    private IEnumerator Post(string level, string level_complete){ 

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
        
        


        using (UnityWebRequest www = UnityWebRequest.Post(URLforLevel, form))    {
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
