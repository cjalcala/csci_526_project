using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalScreen : MonoBehaviour
{
    public Text[] ingredientText;
    public Text[] costText;
    public Sprite[] spritesList;
    public Image[] ingredientIcon;
    public Image[] coinIcon;
    public Text recipe;
    public Text goalAmt;
    public Text recipeEarning;
    public Image recipeIcon;
    public Image[] goalIcon;
   // public static Image coinSanctumImg;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        int index = 0;
        if (GameTracker.ingredientsList.Count == 3)
            index = 1;
        
        foreach (KeyValuePair<string, Ingredient> pair in GameTracker.ingredientsList)
        {
            //ingredientText[index].text = "x" + pair.Value.requiredCount;
            //costText[index].text = pair.Value.cost.ToString();
            ingredientIcon[index].sprite = Resources.Load<Sprite>("Sprites/" + pair.Key.ToString());

            //ingredientText[index].gameObject.SetActive(true);
            //costText[index].gameObject.SetActive(true);
            ingredientIcon[index].gameObject.SetActive(true);
            //coinIcon[index].gameObject.SetActive(true);
            index++;
        }

        recipe.text = GameTracker.recipe.name;
        //goalAmt.text = GameTracker.goalAmt.ToString();
        //recipeEarning.text = GameTracker.recipe.earning.ToString();
        recipeIcon.sprite = Resources.Load<Sprite>("Sprites/" + GameTracker.recipe.name);

        recipe.gameObject.SetActive(true);
        //goalAmt.gameObject.SetActive(true);
        //recipeEarning.gameObject.SetActive(true);
        recipeIcon.gameObject.SetActive(true);

        for (int i = 0; i < GameTracker.goalAmt; i++)
        {
            goalIcon[i].sprite = Resources.Load<Sprite>("Sprites/" + GameTracker.recipe.name);
            goalIcon[i].gameObject.SetActive(true);
        }
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
        GameTracker.LoadScenes();
    }

}
