using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;
    public float speed = 10;
    public Rigidbody rb;
    public float horizontalMultiplier = 0.5f;
    public float jumpForce = 600f;
    public LayerMask groundMask;

    float horizontalInput;
    public GameOverScreen gameOverScreen;
    public bool stayStill = false;

    private void FixedUpdate()
    {
        if(!alive) return;
        if (!stayStill)
        {
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); 

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(transform.position.y < -5) {
            Die();
        }
<<<<<<< Updated upstream
=======

        //distanceRemaining.text = "Distance Remaining: " + (150-rb.position.z).ToString("0"); 
>>>>>>> Stashed changes
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", (float)0.25);
    }

    void Restart ()
    {
        gameOverScreen.Setup();
    }

    void Jump() 
    {
        // Check if we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2)+0.1f, groundMask);

        // If we are, jump
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        
    }
<<<<<<< Updated upstream
=======

    void Start()
    {
        //distanceRemaining = GameObject.Find("DistanceText").GetComponent<Text>();
    }
>>>>>>> Stashed changes
}
