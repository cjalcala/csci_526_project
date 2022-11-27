using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.GetComponent<CookingStation>() != null){
            Destroy(gameObject);
            return;

        }
        if (other.gameObject.name != "Player") 
        {
            return;
        }
        if (GameTracker.coins >= 2)
        {
            GameManager.inst.IncrementIngredient1Count();
            Destroy(gameObject);
        }
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
