using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public float speed = 5;
    float horizontalDir = 1;
    public Rigidbody rb;

    public static bool hit = false;
    int r=1;
    int l=0;

    PlayerMovement playerMovement;

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

        if (!Welcome.immunity && !hit && !GameTracker.sanctumImmunity)
        {
            
            if (InventorySystemManager.inst.qSize() != 0) 
            {
                InventorySystemManager.inst.loseRecentIngredient();
            }
            else if (GameTracker.health != 1)
            {
                GameTracker.health--;
                hit = true;
            }
            else
            {
                playerMovement.Die("obstacle");
            }
        }
        else
        {
            if (!hit)
            {
                Destroy(gameObject);
            }
        }
       


        // hit = false;
        //Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Vector3 horizontalMove = transform.right * horizontalDir * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + horizontalMove);
    }

    private void OnCollisionExit(Collision collision)
    {
        // if (collision.gameObject.name == "Player" && !Welcome.immunity && hit)
        if (collision.gameObject.name == "Player" && hit && !Welcome.immunity)
        {
            hit = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x >= 4f)
        {
            //horizontalDir = -1;
            if(r==1)
            {
                rb.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
                l=1;
                r=0;
            }
            
            //Debug.Log("right");
        }
        else if (rb.position.x <= -4f)
        {
            //horizontalDir = 1;
            //Debug.Log("left");
            if(l==1)
            {
                rb.transform.Rotate(0.0f, 180.0f, 0.0f, Space.World);
                l=0;
                r=1;
            }
        }
    }
}
