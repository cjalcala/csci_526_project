using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public float speed = 5;
    float horizontalDir = 1;
    public Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        int ingredient_one_count=GameTracker.ingred1;
        int ingredient_two_count=GameTracker.ingred2;
        int ingredient_three_count=GameTracker.ingred3;
        
        if(ingredient_one_count==0 && ingredient_two_count==0 && ingredient_three_count==0)
        {
            GameTracker.health-=1;
        }
        else if(ingredient_one_count!=0 && ingredient_two_count==0 && ingredient_three_count==0)
        {
            GameTracker.ingred1-=1;
        }
        else if(ingredient_one_count==0 && ingredient_two_count!=0 && ingredient_three_count==0)
        {
            GameTracker.ingred2-=1;
        }
        else if(ingredient_one_count==0 && ingredient_two_count==0 && ingredient_three_count!=0)
        {
            GameTracker.ingred3-=1;
        }
        else if(ingredient_one_count!=0 && ingredient_two_count!=0 && ingredient_three_count==0)
        {
            int rand=Random.Range(1,3);
            if (rand == 1) {
                GameTracker.ingred1-=1;
            }
            else
            {
                GameTracker.ingred2-=1;
            }
        }
        else if(ingredient_one_count!=0 && ingredient_two_count==0 && ingredient_three_count!=0)
        {
            int rand=Random.Range(1,3);
            if (rand == 1) {
                GameTracker.ingred1-=1;
            }
            else
            {
                GameTracker.ingred3-=1;
            }
        }
        else if(ingredient_one_count==0 && ingredient_two_count!=0 && ingredient_three_count!=0)
        {
            int rand=Random.Range(1,3);
            if (rand == 1) {
                GameTracker.ingred2-=1;
            }
            else
            {
                GameTracker.ingred3-=1;
            }
        }
        else
        {
            int rand=Random.Range(1,4);
            if (rand == 1) {
                GameTracker.ingred1-=1;
            }
            else if(rand==2)
            {
                GameTracker.ingred2-=1;
            }
            else
            {
                GameTracker.ingred3-=1;
            }
        }


        //Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Vector3 horizontalMove = transform.right * horizontalDir * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + horizontalMove);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(horizontalDir==1 && rb.position.x>=4.5f)
        {
            horizontalDir=-1;
        }
        else if(horizontalDir==-1 && rb.position.x<=-4.5f)
        {
            horizontalDir=1;
        }
    }
}
