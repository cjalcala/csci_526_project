using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    public static bool immunity;
    public GameTracker gameTracker;

    public void Tutorial() {
        
        SceneManager.LoadScene("TutorialGame");
    }

    public void Beginner() {
        GameTracker.level = 1;
        GameTracker.GameSetup();
        SceneManager.LoadScene("Goals");
    }

    public void Junior() {
        GameTracker.level = 2;
        GameTracker.GameSetup();
        SceneManager.LoadScene("Goals");
    }

    public void Executive() {
        GameTracker.level = 3;
        GameTracker.GameSetup();
        SceneManager.LoadScene("Goals");
    }

    void Start()
    { 
        immunity=false;
        GameTracker.health=5;
        GameTracker.fiftyFiftyCount = 0;
        GameTracker.hintCount = 0;
        GameTracker.ingred1 = 0;
        GameTracker.ingred2 = 0;
        GameTracker.ingred3 = 0;
        //SanctumQuiz.dish = 0;
        GameTracker.dish = 0;
    }
}