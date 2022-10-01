using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGameManager : MonoBehaviour
{

    public int score;
    public static TutorialGameManager inst;
    public Text tutorialCoinText;
    public static int tutCoinCnt;
    public Text timeText; 
    public float time = 120;
    TutorialPlayerMovement tutorialplayerMovement;
    // Start is called before the first frame update

    private void Awake()
    {
        inst = this;
    }

    public void IncrementScore()
    {
        score++;
        tutorialCoinText.text="Coin: "+score;
    }

    void Start()
    {
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        tutCoinCnt=score;
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeText.text = ": " + time.ToString("0") + " Sec";

        }
        else
        {
            tutorialplayerMovement.Die();
        }
    }
}
