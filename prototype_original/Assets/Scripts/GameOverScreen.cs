using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    
    // Start is called before the first frame update
    
    public void Setup ()
    {
        setupFunction();
        gameObject.SetActive(true);
        
    }

    public void RestartButton()
    {
        setupFunction();
        Welcome.immunity = false;
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