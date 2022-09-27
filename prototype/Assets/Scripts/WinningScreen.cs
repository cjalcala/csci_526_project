using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningScreen : MonoBehaviour
{
    public GameManager gameManager;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setup(float timeScore)
    {
        
        ScoreTracker.coins = 0;
        ScoreTracker.ingredientsList = new SortedDictionary<string, Ingredient>();
        ScoreTracker.ingredientsList.Add("Broccoli", new Ingredient("Broccoli", 1));
        ScoreTracker.ingredientsList.Add("Onion", new Ingredient("Onion", 1));
        ScoreTracker.ingredientsList.Add("Steak", new Ingredient("Steak", 1));
        gameObject.SetActive(true);
        timeText.text = "Your Score: " + ScoreTracker.timeRemain.ToString("0") + "!";
    }

    public void NextLevelButton()
    {
        gameManager.won = false;
        ScoreTracker.timeRemain = 120;
        SceneManager.LoadScene("Game");
    }

    public void RestartButton()
    {
        gameManager.won = false;
        ScoreTracker.timeRemain = 120;
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }
}
