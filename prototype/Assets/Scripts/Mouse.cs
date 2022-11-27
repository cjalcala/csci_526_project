using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public float speed = 5;
    float horizontalDir = 1;
    public Rigidbody rb;

    public static bool hit = false;

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

        if (InventorySystemManager.inst.qSize() != 0) {
            InventorySystemManager.inst.loseRecentIngredient();
        }
        else if (GameTracker.health != 1) {
            hit = true;
            GameTracker.health--;
        }
        else {
            playerMovement.Die("obstacle");
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
        if (collision.gameObject.name == "Player" && hit)
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
        if (horizontalDir == 1 && rb.position.x >= 4.5f)
        {
            horizontalDir = -1;
        }
        else if (horizontalDir == -1 && rb.position.x <= -4.5f)
        {
            horizontalDir = 1;
        }
    }
}
