using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTracker : MonoBehaviour
{
    public static bool insufficientCoins = false;
    public static SortedDictionary<string, Ingredient> ingredientsList;
    public static int coins = 10;
    public static Recipe recipe;
    public static int goalAmt;

    // ingredient along the path
    public static int cucumber;
    public static int lemon;
    public static int yogurt;

    public static float timeRemain, originalTime, tutorialOriginalTime;
    public static float hammerStartTime;
    public static int hammerFlag=0;
    public static string coinString = "";
    public static int timeFlag = 1;
    public static bool sentAnalytics = false;
    public static int level = 1;
    public static QuestionGenerator questionGenerator;
    public static int health=5;
    public static bool getFiftyFiftyPowerUp = false;
    public static int fiftyFiftyPopUpFlag = 0;
    public static int fiftyFiftyCount = 0;
    public static float fiftyFiftyPopUpStartTime;
    public static void increaseIngredient(string name)
    {
        GameTracker.ingredientsList[name].currentCount++;
    }

    public static List<string> uncompletedIngredients()
    {
        List<string> keyList = new List<string>();

        foreach (KeyValuePair<string, Ingredient> pair in ingredientsList)
        {
            if (pair.Value.currentCount < pair.Value.requiredCount)
            {
                keyList.Add(pair.Key);
            }
        }

        return keyList;
    }

    public static void GameSetup()
    {
        if (level == 1)
        {
            timeRemain = 90;
            
            ingredientsList = new SortedDictionary<string, Ingredient>();
            ingredientsList.Add("cucumber", new Ingredient("Cucumber", 1, 2));
            ingredientsList.Add("lemon", new Ingredient("Lemon", 1, 2));
            ingredientsList.Add("yogurt", new Ingredient("Yogurt", 1, 2));
            recipe = new Recipe("Tzatziki Sauce", 15);

            goalAmt = 15;

        }
        else if (level == 2)
        {
            timeRemain = 110;

            ingredientsList = new SortedDictionary<string, Ingredient>();
            ingredientsList.Add("Bread", new Ingredient("Bread", 1, 2));
            ingredientsList.Add("Avocado", new Ingredient("Avocado", 1, 2));
            ingredientsList.Add("Mushroom", new Ingredient("Mushroom", 1, 2));
            ingredientsList.Add("Tomato", new Ingredient("Tomato", 1, 2));
            ingredientsList.Add("Pepper", new Ingredient("Pepper", 1, 2));
            recipe = new Recipe("Tomato Basil Soup", 30);

            goalAmt = 30;
        }

        coins = 10;
        originalTime = GameTracker.timeRemain;
        //tutorialOriginalTime = TutorialGameManager.time;
        questionGenerator = new QuestionGenerator();
    }

    public static void LoadScenes()
    {
        if (level == 1)
            SceneManager.LoadScene("Game");
        else if (level == 2)
            SceneManager.LoadScene("Level2");
    }

    
}
