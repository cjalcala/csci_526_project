using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        //this.gameObject.GetComponent<BoxCollider>.enabled = false;
        player.GetComponent<PlayerMovement>().Death();
    }

}
