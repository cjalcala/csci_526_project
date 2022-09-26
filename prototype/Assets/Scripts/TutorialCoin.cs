using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCoin : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.GetComponent<TutorialObstacle>()!=null)
        {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Add to the player's score
        TutorialGameManager.inst.IncrementScore();
       
        // Destroy this coin object
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed*Time.deltaTime);
    }
}
