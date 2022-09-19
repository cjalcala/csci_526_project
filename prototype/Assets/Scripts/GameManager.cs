using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream

    public int score;
    public static GameManager inst;
    public Text scoreText;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
=======
    public static GameManager inst;
    public int coins = 0, broco;
    public Text coinText;
    public float timeRemain, originalTime;
    public Text timeText;
    public Text goalText;
    public GameOverScreen gameOverScreen;
    public WinningScreen winningScreen;
    public bool won = false;
    PlayerMovement playerMovement;
    public SortedDictionary<string, Ingredient> ingredientsList;
    
    //public int score;
    //public int greenScore;
    //public Text scoreText;
    //public Text greenScoreText;
    
    /*
    public void IncrementScore()
    {
        score--;
        scoreText.text = "Bag Size: " + score;
    }
    public void IncrementGreenScore()
    {
        greenScore++;
        greenScoreText.text = "Green Score: " + greenScore; 
    }
    */
    public void IncrementCoinCount()
    {
        coins++;
        coinText.text = "Coins: " + coins;
    }

    public void increaseIngredient(string name)
    {
        ingredientsList[name].currentCount++;
        goalText.text = "Goal :" + goalProgress();
    }

    public bool checkIngredientsGoal()
    {
        bool goalReached = true;
        foreach (KeyValuePair<string, Ingredient> pair in ingredientsList)
        {
            goalReached = goalReached && pair.Value.currentCount == pair.Value.requiredCount;
        }

        return goalReached;
    }

    public string goalProgress()
    {
        string goal = "";
        foreach (KeyValuePair<string, Ingredient> pair in ingredientsList)
        {
            goal += " " + pair.Key.ToString() + " (" + pair.Value.currentCount + "/" + pair.Value.requiredCount + ")";
        }

        return goal;
>>>>>>> Stashed changes
    }

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        
=======
        //score=10;
        originalTime = timeRemain;
        ingredientsList = new SortedDictionary<string, Ingredient>();
        ingredientsList.Add("Broccoli", new Ingredient("Broccoli", 1));
        ingredientsList.Add("Onion", new Ingredient("Onion", 1));
        ingredientsList.Add("Chicken", new Ingredient("Chicken", 1));

        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();

        goalText.text = "Goal :" + goalProgress();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======

        if (timeRemain >= 0 && checkIngredientsGoal())
        {
            if (!won)
            {
                winningScreen.Setup(originalTime - timeRemain);
                won = true;
            }
            timeRemain = 0;
            playerMovement.stayStill = true;
            
        }
        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
            timeText.text = "Time Remaining: " + timeRemain.ToString("0") + " Sec";

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
            timeRemain = -1;
            playerMovement.stayStill = true;
            //Invoke("Restart", 1);
        }

        /*
        if(score<0 || (greenScore == 5 && yellowScore == 3))
        {
            Invoke("Restart", 1);
        }
        */
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
>>>>>>> Stashed changes
    }
}
