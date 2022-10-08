using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    public static bool immunity;

    public void Tutorial() {
        SceneManager.LoadScene("TutorialGame");
    }

    public void Beginner() {
        SceneManager.LoadScene("Goals");
    }

    public void Junior() {
        SceneManager.LoadScene("Goals");
    }

    public void Executive() {
        SceneManager.LoadScene("Goals");
    }

    void Start()
    { 
        immunity=false;
    }
}