using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningScreen : MonoBehaviour
{

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
        gameObject.SetActive(true);
        timeText.text = "Your Score: " + timeScore.ToString("0") + "!";
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }
}
