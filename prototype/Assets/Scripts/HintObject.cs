using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintObject : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }
        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player") {
            return;
        }
        // add to tracker
        if (!TutorialManager.tutorialActive) {
            GameManager.inst.IncrementHintCount();
            GameTracker.getHintPowerUp = true;
        }
        else {
            TutorialGameManager.hintCount += 1;
        }

        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
