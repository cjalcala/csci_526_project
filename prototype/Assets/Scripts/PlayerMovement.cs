using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;
    public float speed = 10;
    public Rigidbody rb;
    public float horizontalMultiplier = 2;
    public float jumpForce = 600f;
    public LayerMask groundMask;
    public Text distanceRemaining;
    float horizontalInput;

    private void FixedUpdate()
    {
        if(!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
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

        distanceRemaining.text = "Distance Remaining: " + (150-rb.position.z).ToString("0"); 
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", 2);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump() 
    {
        // Check if we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2)+0.1f, groundMask);

        // If we are, jump
        rb.AddForce(Vector3.up*jumpForce);
    }

    void Start()
    {
        distanceRemaining = GameObject.Find("DistanceText").GetComponent<Text>();
    }
}
