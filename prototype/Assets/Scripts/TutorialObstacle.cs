using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    TutorialPlayerMovement tutorialplayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
 
            tutorialplayerMovement.Die();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
