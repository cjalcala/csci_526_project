using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for(int i=0;i<popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }


        if(popUpIndex==0)
        {
            GameObject.Find("LeftRight").SetActive(true);
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
            }
        }
        
    }
}
