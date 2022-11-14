using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int flag =0;
    bool hit = false;


    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player" && !Welcome.immunity && !hit)
        {
            Debug.Log(GameTracker.health);
            hit=true;
            if(GameTracker.health!=1)
            {
                GameTracker.health--;
            }
            else
            {
                flag++;
                if (flag == 1)
                {
                    playerMovement.Die("obstacle");
                }
            }
            
            // Kill the player
            
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
