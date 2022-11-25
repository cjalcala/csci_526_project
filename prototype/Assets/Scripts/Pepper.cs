using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepper : MonoBehaviour
{
     private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name != "Player") {
            Destroy(gameObject);
            return;
        }
        if (GameTracker.coins >= 2)
        {
            GameManager.inst.IncrementIngredient2Count();
            InventorySystemManager.inst.addIngredent("Pepper");
            player2bag.inst.MoveToBag("Pepper");
            GameManager.inst.displayIngredentInBag();
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
