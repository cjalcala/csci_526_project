using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static bool insufficientCoins = false;
    public static SortedDictionary<string, Ingredient> ingredientsList;
    public static int coins;
    public static float timeRemain, originalTime;
    public static float hammerStartTime;
    public static int hammerFlag=0;
    public static string coinString = "";
    public static int timeFlag = 1;
    public static void increaseIngredient(string name)
    {
        ScoreTracker.ingredientsList[name].currentCount++;
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
        
}
