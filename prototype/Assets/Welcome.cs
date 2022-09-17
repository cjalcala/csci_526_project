using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    public void Tutorial() {
        SceneManager.LoadScene("Tutorial");
    }

    public void Beginner() {
        SceneManager.LoadScene("SampleScene");
    }

    public void Junior() {
        SceneManager.LoadScene("SampleScene");
    }

    public void Executive() {
        SceneManager.LoadScene("SampleScene");
    }
}