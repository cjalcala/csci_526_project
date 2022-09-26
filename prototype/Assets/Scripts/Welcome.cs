using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
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
}