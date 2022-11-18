using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialIngredent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        {
            if (other.gameObject.GetComponent<TutorialObstacle>() != null) {
                Destroy(gameObject);
                return;

            }

                if (other.gameObject.name != "Player") {
               // Destroy(gameObject);
                return;
            }
            if (TutorialGameManager.tutCoinCnt >= 2) {
                TutorialManager.getIngredent = true;
                TutorialGameManager.ingredientNum+=1;
                TutorialGameManager.tutCoinCnt -= 2;
            Destroy(gameObject);
           }
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
