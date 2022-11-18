using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiftFiftyObject : MonoBehaviour
{
    public float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other) {

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player") {
            Destroy(gameObject);
            return;
        }
        // add to tracker
         if (!TutorialManager.tutorialActive) {
            GameManager.inst.IncrementFifityFiftyCount();
            GameTracker.getFiftyFiftyPowerUp = true;
        }
        else {
            TutorialGameManager.fiftyFiftyCount += 1;
        }

        Destroy(gameObject);
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

}
