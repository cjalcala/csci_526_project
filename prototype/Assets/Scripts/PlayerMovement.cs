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

    public int flag = 0;

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
            flag++;
            Die("fall");
            
        }

        //distanceRemaining.text = "Distance Remaining: " + (150-rb.position.z).ToString("0"); 
    }

    public void Die(string tp)
    {
        alive = false;
        if (tp == "obstacle"){
            GameManager.inst.Send(tp);
        }
        else{

            if (flag == 1){
            GameManager.inst.Send(tp);
        }
        }
        
        
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

    void Start()
    {
        //distanceRemaining = GameObject.Find("DistanceText").GetComponent<Text>();
    }
}
