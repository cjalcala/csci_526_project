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
        GameTracker.GameSetup();
        gameObject.SetActive(true);
        
    }

    public void NextLevelButton()
    {
        gameManager.won = false;
        GameTracker.level += 1;
        GameTracker.GameSetup();
        if (GameTracker.level == 1)
            SceneManager.LoadScene("Game");
        else if (GameTracker.level == 2)
            SceneManager.LoadScene("Level2");
    }

    public void RestartButton()
    {
        gameManager.won = false;
        GameTracker.GameSetup();
        if (GameTracker.level == 1)
            SceneManager.LoadScene("Game");
        else if (GameTracker.level == 2)
            SceneManager.LoadScene("Level2");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }
}
