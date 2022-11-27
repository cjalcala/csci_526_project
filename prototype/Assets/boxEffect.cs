using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxEffect : MonoBehaviour
{
    public Image img;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InventorySystemManager.inst.didGetAllIngredentInBag())
        {
            img.color = Color.green;
        }
        else
        {
            img.color = Color.white;
        }
        StartCoroutine(GetFullIngredient());

    }

    IEnumerator GetFullIngredient()
    {




        if (CookingStation.hit && !InventorySystemManager.inst.didGetAllIngredentInBag())
        {
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    img.color = Color.red;
                    yield return new WaitForSeconds(0.2f);
                }
                else
                {
                    img.color = Color.white;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            img.color = Color.white;
            CookingStation.hit = false;
        }


        // if ((Obstacle.hit || Mouse.hit) && hearts[h].enabled == true)
        // // if (h < 5 && hearts[h].enabled)
        // {
        //     for (int j = h + 1; j < 5; j++) hearts[h].enabled = false;
        //     Mouse.hit = false;
        //     //blink
        //     for (int i = 0; i < 5; i++)
        //     {
        //         if (i % 2 == 0)
        //         {
        //             hearts[h].enabled = false;
        //             yield return new WaitForSeconds(0.2f);
        //         }
        //         else
        //         {
        //             hearts[h].enabled = true;
        //             yield return new WaitForSeconds(0.2f);
        //         }
        //     }
        //     hearts[h].enabled = false;
        // }



    }
}
