using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    // public string boostUrl = "https://docs.google.com/forms/u/2/d/e/1FAIpQLSetBeyHiPRKxK16NwZ-K_CnSO82ey5gwFSy7aB8ZVSsNts4ng/formResponse";
    // public string[] boostFields = {"entry.308483421", "entry.53979648", "entry.603658436" };
    // public static int boostFieldsCount = 3;
    // public string[] boostValues = new string[boostFieldsCount];
    // public bool hasHitBoost = false;

    // public int timeboost = 0;
    

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
        hammerboost += 1; 
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
