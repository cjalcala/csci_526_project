using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimePowerUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.name != "Player")
        {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        // if (other.gameObject.name == "Player")
        // {
        // GameManager.inst.timeOnText.text = "Timer Counter Slow Down For 5 SEC";

        // }
        if(TutorialManager.tutorialActive)
        {
            TutorialGameManager.inst.TimePowerUp = true;
            TutorialGameManager.inst.TimePowerUpStart = TutorialGameManager.time;
            TutorialGameManager.inst.timeText.color = Color.yellow;
        }
        else
        {
            GameManager.inst.TimePowerUp = true;
            GameManager.inst.TimePowerUpStart = GameTracker.timeRemain;
            GameManager.inst.timeText.color = Color.yellow;
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
        transform.Rotate(0, 0, 45f * Time.deltaTime);
    }
}
