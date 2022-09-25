using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    //TutorialGroundTile tutorialgroundTile;
    public GameObject tutorialobstacleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        //tutorialgroundTile=GameObject.FindObjectOfType<TutorialGroundTile>();
        //tutorialobstacleSpawner.SetActive(false);
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
                popUpIndex++;
                //tutorialgroundTile.TutorialSpawnObstacle();
                //GameObject.FindObjectOfType<TutorialGroundTile>().TutorialSpawnObstacle();
                //tutorialobstacleSpawner.SetActive(true);
            }
        }

    }
}
