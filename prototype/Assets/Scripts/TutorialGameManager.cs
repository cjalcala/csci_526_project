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
    public static TutorialGameManager inst;
    public Text tutorialCoinText;
    public static int tutCoinCnt = 10;
    public Text timeText;
    public static float time = 90;

    public static int ingredientNum = 0;
    TutorialPlayerMovement tutorialplayerMovement;
    public static bool isPaused = false;
    public static bool horizontalArrows = false;
    public static bool spaceBar = false;
    public Image TimeSlider;
    public int hflag = 0;
    public Boolean TimePowerUp = false;
    public Image[] hearts;
    public static int health;
    public static int fiftyFiftyCount;
    public static int hintCount;
    public FiftyFiftySprite fiftySprite;
    public HintSprite hintSprite;

    // Start is called before the first frame update

    private void Awake()
    {
        inst = this;
    }

    public int getHealth()
    {
        return health;
    }


    void Start()
    {
        time = 90;
        tutCoinCnt = 10;
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
        isPaused = false;
        horizontalArrows = false;
        spaceBar = false;
        Time.timeScale = 1f;
        health = 5;
        ingredientNum = 0;
        hintCount = 0;
        fiftyFiftyCount = 0;
    }

    IEnumerator ChangeBleed()
    {
        if (TutorialObstacle.hit == true)
        {
            int h = health;
            //blink
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    hearts[h].enabled = false;
                    yield return new WaitForSeconds(0.2f);
                }
                else
                {
                    hearts[h].enabled = true;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            hearts[h].enabled = false;
        }

    }
    
    IEnumerator ChangeBleedHammer()
    {
        while (TutorialManager.hammerFlag != 0)
        {
            yield return new WaitForSeconds(5.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            if ((!isPaused) && (!horizontalArrows) && (!spaceBar))
            {
                time -= Time.deltaTime;
                TimeSlider.fillAmount = time / 90;
                timeText.text = ": " + time.ToString("0") + "";
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
                if (time <= TutorialManager.hammerStartTime - 5)
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
        StartCoroutine(ChangeBleed());

        if (fiftyFiftyCount > 0)
        {
            fiftySprite.Activate();
        }

        if (hintCount > 0)
        {
            hintSprite.Activate();
        }
    }
}
