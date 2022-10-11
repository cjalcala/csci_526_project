using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    
    // Start is called before the first frame update
    
   
   
    

    public void Setup ()
    {
        ScoreTracker.coins = 0;
        ScoreTracker.timeRemain = 120;
        ScoreTracker.ingredientsList = new SortedDictionary<string, Ingredient>();
        ScoreTracker.ingredientsList.Add("Broccoli", new Ingredient("Broccoli", 1));
        ScoreTracker.ingredientsList.Add("Onion", new Ingredient("Onion", 1));
        ScoreTracker.ingredientsList.Add("Steak", new Ingredient("Steak", 1));
        gameObject.SetActive(true);
        
    }

    public void RestartButton()
    {
        ScoreTracker.coins = 0;
        ScoreTracker.timeRemain = 120;
        ScoreTracker.ingredientsList = new SortedDictionary<string, Ingredient>();
        ScoreTracker.ingredientsList.Add("Broccoli", new Ingredient("Broccoli", 1));
        ScoreTracker.ingredientsList.Add("Onion", new Ingredient("Onion", 1));
        ScoreTracker.ingredientsList.Add("Steak", new Ingredient("Steak", 1));
        Welcome.immunity = false;
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }
}
