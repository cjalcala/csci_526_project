using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static bool tutorialActive = false;
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject tutorialobstacleSpawner;
    public float coinWaitTime = 1.75f;
    public float coinDelTime = 3f;
    public float sanctumWaitTime = 1.75f;
    public float sanctumDelTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        tutorialActive = true;
    }

    // Update is called once per frame
    void Update()
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

        if(popUpIndex==0)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex==1)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex=5;
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
                popUpIndex++;

            }   
        }

    }
}
