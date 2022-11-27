using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    // Start is called before the first frame update

    public Text LoseReason;
    
    public void Setup(string reason)
    {
        LoseReason.text = reason;
        setupFunction();
        gameObject.SetActive(true);
        
    }

    public void RestartButton()
    {
        setupFunction();
        Welcome.immunity = false;
        GameTracker.health=5;
        GameTracker.fiftyFiftyCount = 0;
        GameTracker.hintCount = 0;
        GameTracker.ingred1 = 0;
        GameTracker.ingred2 = 0;
        GameTracker.ingred3 = 0;
        //SanctumQuiz.dish = 0;
        GameTracker.dish = 0;
        GameTracker.LoadScenes();
        if (AudioListener.pause == true){
            AudioListener.pause = true;
        }else{
            AudioListener.pause = false;
        }
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }

    private void setupFunction()
    {
        GameTracker.GameSetup();
    }
}
