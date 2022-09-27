using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalScreen : MonoBehaviour
{
    public Text ingredientText;
    public Sprite[] spritesList;
    public Image[] ingredientIcon;
    

    // Start is called before the first frame update
    void Start()
    {

        ScoreTracker.coins = 0;
        ScoreTracker.timeRemain = 120;
        ScoreTracker.originalTime = ScoreTracker.timeRemain;

        ScoreTracker.ingredientsList = new SortedDictionary<string, Ingredient>();
        ScoreTracker.ingredientsList.Add("Broccoli", new Ingredient("Broccoli", 1));
        ScoreTracker.ingredientsList.Add("Onion", new Ingredient("Onion", 1));
        ScoreTracker.ingredientsList.Add("Steak", new Ingredient("Steak", 1));

        GameObject canvas = GameObject.Find("Canvas");
        int index = 0;
        string ingredientList = "                 ";
        foreach (KeyValuePair<string, Ingredient> pair in ScoreTracker.ingredientsList)
        {
            //ingredientList += " " + pair.Key.ToString() + " x" + pair.Value.requiredCount;
            ingredientList += "         x" + pair.Value.requiredCount;
            ingredientIcon[index].sprite = Resources.Load<Sprite>("Sprites/" + pair.Key.ToString());
            index++;
        }
        ingredientText.text = ingredientList;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(float timeScore)
    {
        gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("Game");
    }

}
