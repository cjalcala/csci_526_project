using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        score++;
        scoreText.text = "Score: " + score;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
