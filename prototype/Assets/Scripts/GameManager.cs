using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    //public int coins = 0;
    public Text coinText;
    public Text timeText;
    public Text goalText;
    public GameOverScreen gameOverScreen;
    public WinningScreen winningScreen;
    public bool won;
    PlayerMovement playerMovement;
    //public SortedDictionary<string, Ingredient> ingredientsList;

    public void IncrementCoinCount()
    {
        ScoreTracker.coins++;
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
}
