using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    TutorialPlayerMovement tutorialplayerMovement;
    bool hit = false;
    public int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player" && !Welcome.immunity && !hit)
        {
            hit=true;
            if(TutorialGameManager.health!=1)
            {
                TutorialGameManager.health--;
            }
            else
            {
                flag++;
                if (flag == 1)
                {
                    tutorialplayerMovement.Die();
                }
            }
        }
        else 
        {
            if(!hit)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Player" && !Welcome.immunity && hit)
        {
            hit=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
