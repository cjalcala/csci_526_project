using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static bool tutorialActive = false;
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject tutorialobstacleSpawner;
    public float spaceWaitTime = 2.5f;
    public float coinWaitTime = 2f;
    public float coinDelTime = 4f;
    public float sanctumWaitTime = 2.5f;
    public float sanctumDelTime = 4.5f;
    TutorialPlayerMovement tutorialplayerMovement;
    public static QuestionGenerator questionGenerator;

    // Start is called before the first frame update
    void Start()
    {
        tutorialActive = true;
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
        questionGenerator = new QuestionGenerator();
    }

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
                        popUpIndex = 4;
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
                else if(popUpIndex==4)
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
                        popUpIndex=5;
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
                else if(popUpIndex==5)
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
                        popUpIndex=6;

                    }   
                }
                else if(popUpIndex==6)
                {
                    if(sanctumWaitTime>0)
                    {
                        sanctumWaitTime-=Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex=3;
                    }
                }
                else if(popUpIndex==3)
                {
                    if(sanctumDelTime>0)
                    {
                        sanctumDelTime-=Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex = 10;

                    }   
                }

            }
        }
    }
}
