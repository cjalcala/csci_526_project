using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public int greenScore;
    public int yellowScore;
    public static GameManager inst;
    public Text scoreText;
    public Text greenScoreText;
    public Text yellowScoreText;
    public void IncrementScore()
    {
        score--;
        scoreText.text = "Bag Size: " + score;
    }
    public void IncrementGreenScore()
    {
        greenScore++;
        greenScoreText.text = "Green Score: " + greenScore; 
    }
    public void IncrementYellowScore()
    {
        yellowScore++;
        yellowScoreText.text = "Yellow Score: " + yellowScore;
    }

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score=10;
    }

    // Update is called once per frame
    void Update()
    {
        if(score<0)
        {
            Invoke("Restart", 1);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
