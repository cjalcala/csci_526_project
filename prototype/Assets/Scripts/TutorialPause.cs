using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPause : MonoBehaviour
{
    TutorialPlayerMovement tutorialplayerMovement;
    public GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.P)) {
            if(TutorialGameManager.isPaused) {
                resumeTutorial();
            } else {
                tutorialpauseButton();
            }
        }
        
    }

    public void tutorialpauseButton()
    {
        TutorialGameManager.isPaused = true;
        tutorialplayerMovement.speed = 0;
        tutorialplayerMovement.horizontalMultiplier = 0;
        tutorialplayerMovement.jumpForce = 0;
        Time.timeScale = 0f;
        PausePanel.SetActive(true);   
    }

    public void resumeTutorial()
    {
        PausePanel.SetActive(false);   
        TutorialGameManager.isPaused = false;
        Time.timeScale = 1f;
        tutorialplayerMovement.speed = 8;
        tutorialplayerMovement.horizontalMultiplier = 0.8f;
        tutorialplayerMovement.jumpForce = 750f;
    }

    public void restartTutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exitTutorial()
    {   
        Time.timeScale = 1f;
        SceneManager.LoadScene("WelcomeScreen");
    }

}
