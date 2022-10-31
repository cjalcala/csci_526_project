using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
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
    public float sanctumWaitTime = 5.5f;
    public float sanctumDelTime = 4.5f;
    public static int hammerCount = 0;
    public static int clockCount = 0;
    public static float tutorialOriginalTime;
    TutorialPlayerMovement tutorialplayerMovement;
    public static QuestionGenerator questionGenerator;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        tutorialActive = true;
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
        questionGenerator = new QuestionGenerator();
    }

    // public static void GameSetup()
    // {
    //     tutorialOriginalTime = TutorialGameManager.time;
    // }

    // Update is called once per frame
    void Update()
    {
        
        if(TutorialGameManager.time < 89)
        {
            for(int i=0;i<popUps.Length; i++)
            {
                if(i == popUpIndex)
                {
                    popUps[i].SetActive(true);
                }
                else
                {
                    popUps[i].SetActive(false);
                }
            }

            if(!TutorialGameManager.isPaused)
            {
                if(popUpIndex==0)
                {
                    if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                    {
                        TutorialGameManager.horizontalArrows = false;
                        Time.timeScale = 1f;

                        tutorialplayerMovement.speed = 8;
                        tutorialplayerMovement.horizontalMultiplier = 0.8f;
                        tutorialplayerMovement.jumpForce = 750f;
                        popUpIndex = 6;

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
                else if(popUpIndex==6)
                {
                    if(spaceWaitTime>0)
                    {
                        spaceWaitTime-=Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex=1;
                    }
                }
                else if(popUpIndex==1)
                {
                    if(Input.GetKeyDown(KeyCode.Space))
                    {
                        TutorialGameManager.spaceBar = false;
                        Time.timeScale = 1f;

                        tutorialplayerMovement.speed = 8;
                        tutorialplayerMovement.horizontalMultiplier = 0.8f;
                        tutorialplayerMovement.jumpForce = 750f;
                        popUpIndex=7;

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
                else if(popUpIndex==7)
                {
                    if(coinWaitTime>0)
                    {
                        coinWaitTime-=Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex=2;
                    }
                }
                else if(popUpIndex==2)
                {
                    if(coinDelTime>0)
                    {
                        coinDelTime-=Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex=8;

                    }   
                }
                else if(popUpIndex==8)
                {
                    if(hammerWaitTime>0)
                    {
                        hammerWaitTime-=Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex=3;
                    }
                }
                else if(popUpIndex==3)
                {
                    if(!Input.GetKeyDown(KeyCode.Return))
                    {
                        Time.timeScale = 0f;
                        tutorialplayerMovement.speed = 0;
                        tutorialplayerMovement.horizontalMultiplier = 0;
                        tutorialplayerMovement.jumpForce = 0;
                    }
                    else 
                    {
                        //hammerDelTime-=Time.deltaTime;
                        Time.timeScale = 1f;
                        tutorialplayerMovement.speed = 10;
                        tutorialplayerMovement.horizontalMultiplier = 1.25f;
                        tutorialplayerMovement.jumpForce = 600f;  
                        popUpIndex=9;
 
                    }
                }
                else if(popUpIndex==9)
                {
                    if(clockWaitTime>0)
                    {
                        clockWaitTime-=Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex=4;
                    }
                }
                else if(popUpIndex==4)
                {
                    if(!Input.GetKeyDown(KeyCode.Return))
                    {
                        Time.timeScale = 0f;
                        tutorialplayerMovement.speed = 0;
                        tutorialplayerMovement.horizontalMultiplier = 0;
                        tutorialplayerMovement.jumpForce = 0;
                    }
                    else 
                    {
                        //clockDelTime-=Time.deltaTime;
                        Time.timeScale = 1f;
                        tutorialplayerMovement.speed = 10;
                        tutorialplayerMovement.horizontalMultiplier = 1.25f;
                        tutorialplayerMovement.jumpForce = 600f;   
                        popUpIndex = 10;
                    }
                }
                else if(popUpIndex==10)
                {
                    if(sanctumWaitTime>0)
                    {
                        sanctumWaitTime-=Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex=5;
                    }
                }
                else if(popUpIndex==5)
                {
                    if(sanctumDelTime>0)
                    {
                        sanctumDelTime-=Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex = 11;

                    }   
                }

            }
        }
    }
}
