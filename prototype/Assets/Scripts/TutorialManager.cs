using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour//control all pop-up texts in the tutorial game
{
    public static int hammerFlag = 0;
    public static float hammerStartTime;
    public static bool tutorialActive = false;
    public GameObject[] popUps;
    public static int popUpIndex;
    public float spaceWaitTime = 4f;
    public float hammerWaitTime = 3f;
    public float hammerDelTime = 3f;
    public float clockWaitTime = 5f;
    public float clockDelTime = 5f;
    public float cookStationWaitTime = 5.5f;
    public float cookStationDelTime = 4.5f;
    public float fiftyFiftyWaitTime = 5.5f;
    public float fifityFiftyDisplayTime = 5f;
    public float hintDisplayTime = 5f;
    public float getIngredentDisplayTime = 5.5f;

    public static int clockCount = 0;
    public static float tutorialOriginalTime;
    TutorialPlayerMovement tutorialplayerMovement;
    public static QuestionGenerator questionGenerator;

    public static bool getIngredent = false;
    // Start is called before the first frame update
    // private int currentState;
    void Start()
    {
        Time.timeScale = 1f;
        tutorialActive = true;
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
        questionGenerator = new QuestionGenerator();
        getIngredent = false;
        popUpIndex = 0;

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
            // for (int i = 0; i < popUps.Length; i++)
            // {
            //     if (i == popUpIndex)
            //     {
            //         popUps[i].SetActive(true);
            //     }
            //     else
            //     {
            //         popUps[i].SetActive(false);
            //     }
            // }
            //leftright jump hammer clock 50-50 hint onion cookingstation
            if (!TutorialGameManager.isPaused)
            {
                if (popUpIndex == 0)
                {
                    popUps[0].SetActive(true);
                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Space))//left right
                    {
                        TutorialGameManager.horizontalArrows = false;
                        Time.timeScale = 1f;

                        tutorialplayerMovement.speed = 8;
                        tutorialplayerMovement.horizontalMultiplier = 0.8f;
                        tutorialplayerMovement.jumpForce = 750f;
                        // popUpIndex = getInsCompletedIndex(0);
                        popUpIndex = 1;
                        popUps[0].SetActive(false);

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
                // else if (popUpIndex == getInsCompletedIndex(0))
                // {
                //     if (spaceWaitTime > 0)
                //     {
                //         spaceWaitTime -= Time.deltaTime;
                //     }
                //     else
                //     {
                //         popUpIndex = 1;
                //     }
                // }
                // heart loss
                else if (popUpIndex == 1)
                {
                    // health
                    if (TutorialGameManager.health < 5)
                    {
                        popUpIndex = 2;
                        TutorialGroundSpawner.showArrow = false;
                    }
                    else
                    {
                        //**** WJY : how to make sure the target is out of the scene
                        // groundSpawner.showArrow = false;
                    }
                }
                //*** don't understand this part
                // else if (popUpIndex == getInsCompletedIndex(1))
                // {
                //     if (hammerWaitTime > 0)
                //     {
                //         hammerWaitTime -= Time.deltaTime;
                //     }
                //     else
                //     {
                //         popUpIndex = 2;
                //     }
                // }
                // power-up hammer
                else if (popUpIndex == 2)
                {
                    if (hammerFlag == 1)
                    {
                        popUpIndex = 20;
                        TutorialGroundSpawner.showArrow = false;
                    }

                }
                // next step for obstacle
                else if (popUpIndex == 20)
                {
                    if (hammerFlag == 0)
                    {
                        popUpIndex = 3;
                        TutorialGroundSpawner.showArrow = false;
                    }

                }
                // else if (popUpIndex == getInsCompletedIndex(2))
                // {
                //     if (clockWaitTime > 0)
                //     {
                //         clockWaitTime -= Time.deltaTime;
                //     }
                //     else
                //     {
                //         popUpIndex = 3;
                //     }
                // }
                // 50-50 
                else if (popUpIndex == 3)//clock
                {
                    if (TutorialGameManager.fiftyFiftyCount > 0)
                    {
                        popUpIndex = 4;
                        TutorialGroundSpawner.showArrow = false;
                    }

                }
                // else if (popUpIndex == getInsCompletedIndex(3))
                // {
                //     if (fiftyFiftyWaitTime > 0)
                //     {
                //         fiftyFiftyWaitTime -= Time.deltaTime;
                //     }
                //     else
                //     {
                //         popUpIndex = 4;
                //     }
                // }
                //hints
                else if (popUpIndex == 4)//50-50
                {
                    if (TutorialGameManager.hintCount > 0)
                    {
                        popUpIndex = 5;
                        TutorialGroundSpawner.showArrow = false;
                    }

                }
                // else if (popUpIndex == getInsCompletedIndex(4))
                // {
                //     if (fifityFiftyDisplayTime > 0)
                //     {
                //         fifityFiftyDisplayTime -= Time.deltaTime;
                //     }
                //     else
                //     {
                //         popUpIndex = 5;
                //     }
                // }
                // onion
                else if (popUpIndex == 5)//hint
                {
                    if (TutorialGameManager.ingredientNum > 0)
                    {
                        popUpIndex = 6;
                        TutorialGroundSpawner.showArrow = false;
                    }
                }
                // else if (popUpIndex == getInsCompletedIndex(5))//hint
                // {
                //     if (hintDisplayTime > 0)
                //     {
                //         hintDisplayTime -= Time.deltaTime;
                //     }
                //     else
                //     {
                //         popUpIndex = 6;
                //     }
                // }
                // Arrow for sanctum
                else if (popUpIndex == 6)//get ingredient
                {
                    // don't know the next step
                }


            }
        }


    }
    public int getInsCompletedIndex(int index)
    {
        return popUps.Length + index;
    }
}
