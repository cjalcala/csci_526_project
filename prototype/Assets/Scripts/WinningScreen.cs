using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningScreen : MonoBehaviour
{
    public GameManager gameManager;
    public Text timeText;
    public GameObject button;

    public Text coinText;
    public Text dishText;
    public Image dishImage;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Pause");

    }

    // Update is called once per frame
    void Update()
    {
        button.SetActive(false);

    }

    public void Setup(float timeScore)
    {
        timeText.text = "Your Score: " + GameTracker.timeRemain.ToString("0") + "!";
        coinText.text = GameTracker.coins.ToString();
        dishText.text = SanctumQuiz.dish.ToString();
        dishImage.sprite = Resources.Load<Sprite>("Sprites/" + GameTracker.recipe.name);
        GameTracker.GameSetup();
        gameObject.SetActive(true);
        
    }

    public void NextLevelButton()
    {
        gameManager.won = false;
        GameTracker.level += 1;
        GameTracker.health=5;
        GameTracker.ingred1 = 0;
        GameTracker.ingred2 = 0;
        GameTracker.ingred3 = 0;
        SanctumQuiz.dish = 0;
        GameTracker.GameSetup();
        //if (GameTracker.level == 2)
        //    SceneManager.LoadScene("Level2");
        //else if (GameTracker.level == 3)
        //    SceneManager.LoadScene("Level3");
        //else if (GameTracker.level == 4)
        //    SceneManager.LoadScene("WelcomeScreen");
        SceneManager.LoadScene("Goals");
    }

    public void RestartButton()
    {
        gameManager.won = false;
        GameTracker.GameSetup();
        GameTracker.health=5;
        GameTracker.ingred1 = 0;
        GameTracker.ingred2 = 0;
        GameTracker.ingred3 = 0;
        SanctumQuiz.dish = 0;
        if (GameTracker.level == 1)
            SceneManager.LoadScene("Game");
        else if (GameTracker.level == 2)
            SceneManager.LoadScene("Level2");
        else if (GameTracker.level == 3)
            SceneManager.LoadScene("Level3");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }
}
