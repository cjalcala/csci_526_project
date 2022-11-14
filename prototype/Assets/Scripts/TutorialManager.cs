using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour//control all pop-up texts in the tutorial game
{
    public static int hammerFlag = 0;
    public static float hammerStartTime;
    public static bool tutorialActive = false;
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject tutorialobstacleSpawner;
    public float spaceWaitTime = 4f;
    public float coinWaitTime = 4.5f;
    public float coinDelTime = 5f;
    public float hammerWaitTime = 3f;
    public float hammerDelTime = 3f;
    public float clockWaitTime = 7f;
    public float clockDelTime = 5f;
    public float cookStationWaitTime = 5.5f;
    public float cookStationDelTime = 4.5f;
    public float fiftyFiftyWaitTime = 5.5f;
    public float fifityFiftyDisplayTime = 5.5f;
    public float hintDisplayTime = 5.5f;
    public static int hammerCount = 0;
    public static int clockCount = 0;
    public static float tutorialOriginalTime;
    TutorialPlayerMovement tutorialplayerMovement;
    public static QuestionGenerator questionGenerator;
    public static bool getIngredent = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        tutorialActive = true;
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
        questionGenerator = new QuestionGenerator();
        getIngredent = false;
    }

    // public static void GameSetup()
    // {
    //     tutorialOriginalTime = TutorialGameManager.time;
    // }

    // Update is called once per frame
    void Update()
    {

        if (TutorialGameManager.time < 89)
        {
            for (int i = 0; i < popUps.Length; i++)
            {
                if (i == popUpIndex)
                {
                    popUps[i].SetActive(true);
                }
                else
                {
                    popUps[i].SetActive(false);
                }
            }
            //leftright jump hammer clock 50-50 hint onion cookingstation
            if(!TutorialGameManager.isPaused)
            {
                if (popUpIndex == 0)
                {
                    if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))//left right
                    {
                        TutorialGameManager.horizontalArrows = false;
                        Time.timeScale = 1f;

                        tutorialplayerMovement.speed = 8;
                        tutorialplayerMovement.horizontalMultiplier = 0.8f;
                        tutorialplayerMovement.jumpForce = 750f;
                        popUpIndex = getInsCompletedIndex(0);

                    }
                    else
                    {
                        TutorialGameManager.horizontalArrows = true;
                        Time.timeScale = 0f;
                        tutorialplayerMovement.speed = 0;
                        tutorialplayerMovement.horizontalMultiplier = 0;
                        tutorialplayerMovement.jumpForce = 0;
                    }
                }
                else if(popUpIndex== getInsCompletedIndex(0))
                {
                    if (spaceWaitTime > 0)
                    {
                        spaceWaitTime -= Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex = 1;
                    }
                }
                else if (popUpIndex == 1)
                {
                    if(Input.GetKeyDown(KeyCode.Space))//jump
                    {
                        TutorialGameManager.spaceBar = false;
                        Time.timeScale = 1f;

                        tutorialplayerMovement.speed = 8;
                        tutorialplayerMovement.horizontalMultiplier = 0.8f;
                        tutorialplayerMovement.jumpForce = 750f;
                        popUpIndex= getInsCompletedIndex(1);

                    }
                    else
                    {
                        TutorialGameManager.spaceBar = true;
                        Time.timeScale = 0f;
                        tutorialplayerMovement.speed = 0;
                        tutorialplayerMovement.horizontalMultiplier = 0;
                        tutorialplayerMovement.jumpForce = 0;
                    }
                }
                else if(popUpIndex== getInsCompletedIndex(1))
                {
                    if (coinWaitTime > 0)
                    {
                        coinWaitTime -= Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex = 2;
                    }
                }
                else if(popUpIndex==2)//pick up cost
                {
                    if (TutorialGameManager.ingredientNum >= 1)
                    {
                        popUpIndex = 3;
                    }
                    else
                    {
                        popUpIndex= getInsCompletedIndex(2);

                    }
                }
                else if(popUpIndex== getInsCompletedIndex(2))
                {
                    if (hammerWaitTime > 0)
                    {
                        hammerWaitTime -= Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex = 3;
                    }
                }
                else if (popUpIndex == 3)
                {
                    if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))//hammer
                    {
                        //hammerDelTime-=Time.deltaTime;
                        Time.timeScale = 1f;
                        tutorialplayerMovement.speed = 8;
                        tutorialplayerMovement.horizontalMultiplier = 0.8f;
                        tutorialplayerMovement.jumpForce = 750f;
                        popUpIndex = getInsCompletedIndex(3);
                    }
                    else 
                    {
                        Time.timeScale = 0f;
                        tutorialplayerMovement.speed = 0;
                        tutorialplayerMovement.horizontalMultiplier = 0;
                        tutorialplayerMovement.jumpForce = 0;

                    }
                }
                else if(popUpIndex== getInsCompletedIndex(3))
                {
                    if (clockWaitTime > 0)
                    {
                        clockWaitTime -= Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex = 4;
                    }
                }
                else if (popUpIndex == 4)//clock
                {
                    if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                    {

                        //clockDelTime-=Time.deltaTime;
                        Time.timeScale = 1f;
                        tutorialplayerMovement.speed = 8;
                        tutorialplayerMovement.horizontalMultiplier = 0.8f;
                        tutorialplayerMovement.jumpForce = 750f;
                        popUpIndex = getInsCompletedIndex(4);
                    }
                    else 
                    {
                        Time.timeScale = 0f;
                        tutorialplayerMovement.speed = 0;
                        tutorialplayerMovement.horizontalMultiplier = 0;
                        tutorialplayerMovement.jumpForce = 0;
                    }
                }
                else if(popUpIndex== getInsCompletedIndex(4))
                {
                    if(fiftyFiftyWaitTime > 0)
                    {
                        fiftyFiftyWaitTime -= Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex = 5;
                    }
                }
                else if(popUpIndex==5)//50-50
                {
                    if (fifityFiftyDisplayTime > 0) {
                        fifityFiftyDisplayTime -= Time.deltaTime;
                    }
                    else {
                        popUpIndex = 6;
                    }
                }

                else if (popUpIndex == 6)//hint
                {
                    if (hintDisplayTime > 0) {
                        hintDisplayTime -= Time.deltaTime;
                    }
                    else {
                        popUpIndex = 7;
                    }
                }

                else if (popUpIndex == 7 &&getIngredent)//cooking station
               {
                    popUpIndex = 7;
                }

            }
        }


    }
    public int getInsCompletedIndex(int index) {
        return popUps.Length + index;
    }
}
