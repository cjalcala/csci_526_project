using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimePowerUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Check that the object we collided with is the player
        // if (other.gameObject.name == "Player")
        // {
        GameManager.inst.TimePowerUp = true;
        GameManager.inst.TimePowerUpStart = ScoreTracker.timeRemain;
        GameManager.inst.timeText.color = Color.red;
        // GameManager.inst.timeOnText.text = "Timer Counter Slow Down For 5 SEC";

        // }


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
