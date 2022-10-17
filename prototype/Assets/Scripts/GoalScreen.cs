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
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        int index = 0;
        if (GameTracker.ingredientsList.Count == 3)
            index = 1;
        
        foreach (KeyValuePair<string, Ingredient> pair in GameTracker.ingredientsList)
        {
            ingredientText[index].text = "x" + pair.Value.requiredCount;
            costText[index].text = pair.Value.cost.ToString();
            ingredientIcon[index].sprite = Resources.Load<Sprite>("Sprites/" + pair.Key.ToString());

            ingredientText[index].gameObject.SetActive(true);
            costText[index].gameObject.SetActive(true);
            ingredientIcon[index].gameObject.SetActive(true);
            coinIcon[index].gameObject.SetActive(true);
            index++;
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
