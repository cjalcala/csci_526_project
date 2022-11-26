using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookingStation : MonoBehaviour
{
    PlayerMovement PlayerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

        if (TutorialManager.tutorialActive)
        {
            SceneManager.LoadScene("Sanctum");

        }
        else
        {
            PlayerMovement.speed = 0;
            PlayerMovement.horizontalMultiplier = 0;
            PlayerMovement.jumpForce = 0;
            SceneManager.LoadScene("Sanctum", LoadSceneMode.Additive);
        }
        
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
