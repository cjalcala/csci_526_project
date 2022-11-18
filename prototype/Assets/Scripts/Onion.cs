using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : MonoBehaviour
{
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name != "Player") {
            Destroy(gameObject);
            return;
        }
        if (GameTracker.coins >= 2)
        {
            GameManager.inst.IncrementIngredient3Count();
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
