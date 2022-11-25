using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basil : MonoBehaviour
{
     private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name != "Player") {
            Destroy(gameObject);
            return;
        }
        if (GameTracker.coins >= 2)
        {
            GameManager.inst.IncrementIngredient1Count();
            InventorySystemManager.inst.addIngredent("Basil");
            player2bag.inst.MoveToBag("Basil");
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
