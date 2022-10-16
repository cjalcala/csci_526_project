using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTracker : MonoBehaviour
{
    public static bool insufficientCoins = false;
    public static SortedDictionary<string, Ingredient> ingredientsList;
    public static int coins;
    public static float timeRemain, originalTime;
    public static float hammerStartTime;
    public static int hammerFlag=0;
    public static string coinString = "";
    public static int timeFlag = 1;
    public static int level = 1;

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
            ingredientsList.Add("Broccoli", new Ingredient("Broccoli", 1, 2));
            ingredientsList.Add("Onion", new Ingredient("Onion", 1, 2));
            ingredientsList.Add("Steak", new Ingredient("Steak", 1, 2));
        }
        else if (level == 2)
        {
            timeRemain = 75;

            ingredientsList = new SortedDictionary<string, Ingredient>();
            ingredientsList.Add("Bread", new Ingredient("Bread", 1, 2));
            ingredientsList.Add("Avocado", new Ingredient("Avocado", 1, 2));
            ingredientsList.Add("Mushroom", new Ingredient("Mushroom", 1, 2));
            ingredientsList.Add("Tomato", new Ingredient("Tomato", 1, 2));
            ingredientsList.Add("Pepper", new Ingredient("Pepper", 1, 2));
        }

        coins = 0;
        originalTime = GameTracker.timeRemain;
    }

    public static void LoadScenes()
    {
        if (level == 1)
            SceneManager.LoadScene("Game");
        else if (level == 2)
            SceneManager.LoadScene("Level2");
    }
        
}