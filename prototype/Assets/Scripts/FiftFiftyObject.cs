using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiftFiftyObject : MonoBehaviour
{
    public float turnSpeed = 90f;
    private float yRange = 1.8f;
    private float move = 1.0f;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }
        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player") {
            Destroy(gameObject);
            return;
        }
        // add to tracker
         if (!TutorialManager.tutorialActive) {
            if(GameTracker.fiftyFiftyCount<1)
            {
                GameManager.inst.IncrementFifityFiftyCount();
                GameTracker.getFiftyFiftyPowerUp = true;
                Destroy(gameObject);
            }
            // else
            // {

            // }
        }
        else {

            if(TutorialGameManager.fiftyFiftyCount<1)
            {
                TutorialGameManager.fiftyFiftyCount += 1;
                //GameTracker.getFiftyFiftyPowerUp = true;
                Destroy(gameObject);
            }
            //TutorialGameManager.fiftyFiftyCount += 1;
        }

        //Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime,0 );

        
    }

    // if we still want to use up&down effect, we can use following code
    // void Update()
    // {
    //     transform.Translate(0.0f, move*Time.deltaTime, 0.0f);

    //     if (transform.position.y > yRange)
    //     {
    //         transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
    //         move = -move;
    //     }
    //     if (transform.position.y < 0.8f)
    //     {
    //         transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);
    //         move = -move;
    //     }
    // }

}
