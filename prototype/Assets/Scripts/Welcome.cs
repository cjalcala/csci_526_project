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
        GameTracker.GameSetup();
        SceneManager.LoadScene("WelcomeScreen");
    }

    void Start()
    { 
        immunity=false;
        GameTracker.health=5;
    }
}