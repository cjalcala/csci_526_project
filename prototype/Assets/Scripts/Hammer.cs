using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    
    private float yRange = 1.8f;
    private float move = 1.0f;
    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>()!=null)
        {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
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
        transform.Translate(0.0f, move*Time.deltaTime, 0.0f);

        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
            move = -move;
        }
        if (transform.position.y < 1f)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            move = -move;
        }
    }
}
