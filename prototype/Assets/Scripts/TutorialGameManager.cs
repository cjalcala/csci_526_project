using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;
using System.Reflection;

public class TutorialGameManager : MonoBehaviour
{

    
    public float TimePowerUpStart = 0;
    public Text hammerOnText;
    public float hammerOnTexttimeDisplay = 1.5f;
    public Text hammerOffText;
    public float hammerOffTexttimeDisplay = 1.5f;
    public int score;
    public static TutorialGameManager inst;
    public Text tutorialCoinText;
    public static int tutCoinCnt;
    public Text timeText; 
    public static float time = 90;
    TutorialPlayerMovement tutorialplayerMovement;
    public static bool isPaused = false;
    public static bool horizontalArrows = false;
    public static bool spaceBar = false;
    public Image TimeSlider;
    public int hflag = 0;
    public Boolean TimePowerUp = false;
    public Image[] hearts;
    public static int health;
    // Start is called before the first frame update

    private void Awake()
    {
        inst = this;
    }

    public void IncrementScore()
    {
        score++;
        tutorialCoinText.text="        : "+score;
    }

    void Start()
    {
        time = 90;
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
        isPaused = false;
        horizontalArrows = false;
        spaceBar = false;
        Time.timeScale = 1f;
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        tutCoinCnt=score;

        if (TimePowerUp && Math.Abs(TutorialGameManager.time - TimePowerUpStart) >= 2.5)
        {
            TimePowerUp = false;
            // timeOffText.text = "Timer Counter Slow Down FINISH";
            timeText.color = Color.black;
        }

        if (time > 0)
        {
            if (TimePowerUp)
            {
                time -= Time.deltaTime / 2;
                TimeSlider.fillAmount = time/90;
                timeText.text = ": " + time.ToString("0") + " Sec SLOW";
                // timeText.color = Color.red;

            }
            else
            {
                time -= Time.deltaTime;
                TimeSlider.fillAmount = time/90;
                timeText.text = ": " + time.ToString("0") + " Sec";
            }

            // int forwardSeconds = (int)GameTracker.originalTime - Convert.ToInt32(Math.Truncate(GameTracker.timeRemain));
            // if ((forwardSeconds == GameTracker.timeFlag) && (GameTracker.sentAnalytics == false))
            // {
            //     GameTracker.coinString = GameTracker.coinString + GameTracker.coins.ToString() + ",";
            //     GameTracker.timeFlag++;
            //     //Debug.Log(GameTracker.coinString);
            // }
        }

        if (time > 0)
        {
            if((!isPaused ) && (!horizontalArrows) && (!spaceBar))
            {
                time -= Time.deltaTime;
                TimeSlider.fillAmount = time/90;
                timeText.text = ": " + time.ToString("0") + " Sec";
            }
        }
        else
        {
            tutorialplayerMovement.Die();
        }


        if (Welcome.immunity)
        {
            if (TutorialManager.hammerFlag == 0)
            {
                TutorialManager.hammerStartTime = TutorialGameManager.time;
                TutorialManager.hammerFlag = 1;
                hammerOnText.text = "Obstacle Immunity for 5 sec";
            }
            else
            {
                if (time <=TutorialManager.hammerStartTime - 5)
                {
                    Welcome.immunity = false;
                    TutorialManager.hammerFlag = 0;
                    hammerOffText.text = "Obstacle Immunity Off";
                    hflag = 1;
                }
            }
        }

        if (TutorialManager.hammerFlag == 1)
        {
            if (hammerOnTexttimeDisplay < 0)
            {
                hammerOnText.text = "";
                hammerOnTexttimeDisplay = 1.5f;
            }
            else
            {
                hammerOnTexttimeDisplay -= Time.deltaTime;
                // hammerOnTexttimeDisplay -= (TimePowerUp ? Time.deltaTime / 2 : Time.deltaTime);
            }
        }

        if (hflag == 1)
        {
            if (hammerOffTexttimeDisplay < 0)
            {
                hammerOffText.text = "";
                hammerOffTexttimeDisplay = 1f;
            }
            else
            {
                hammerOffTexttimeDisplay -= Time.deltaTime;
                // hammerOffTexttimeDisplay -= (TimePowerUp ? Time.deltaTime / 2 : Time.deltaTime);
            }
        }


        if(health<5)
        {
            for(int h=health;h<=4;h++)
            {
                hearts[h].enabled=false;
            }
        }
    }
}
