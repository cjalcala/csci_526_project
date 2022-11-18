using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    private void OnTriggerEnter (Collider other)
    {
        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player") {
            Destroy(gameObject);
            return;
        }
        Welcome.immunity = true;
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
