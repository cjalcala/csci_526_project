using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int flag =0;


    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player" && !Welcome.immunity)
        {
            flag++;
            if (flag == 1){
                playerMovement.Die("obstacle");
            }
            // Kill the player
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
