using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;
    public float speed = 10;
    public Rigidbody rb;
    public float horizontalMultiplier = 0.5f;
    public float jumpForce = 3000f;
    public LayerMask groundMask;

    float horizontalInput;
    public GameOverScreen gameOverScreen;
    public bool stayStill = false;

    // find the pause button
    public GameObject button;
    public GameObject ObjectMusic;

    
    [SerializeField] private AudioSource jump_sound;
    [SerializeField] private AudioSource obstacle_hit_sound;

    public void Start() {
        button = GameObject.Find("Pause");
    }


    

    
    

    public int flag = 0;

    private void FixedUpdate()
    {
        if (!alive) return;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y < -5)
        {
            flag++;
            Die("fall");
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), transform.position.y, transform.position.z);
    }

    public void Die(string tp)
    {
        alive = false;

        // disable pause button
        button.SetActive(false);
        


        if (tp == "obstacle")
        {
            GameManager.inst.NewSend("false");
            //GameManager.inst.Send(tp);
            GameManager.inst.hasHitObstacle = true;
            obstacle_hit_sound.Play();
            GameManager.inst.deathValues[0] = GameManager.inst.timestamp.ToString();
            GameManager.inst.deathValues[1] = GameManager.inst.sessionNum.ToString();
            GameManager.inst.deathValues[2] = "lost";
            GameManager.inst.deathValues[3] = tp;
            GameManager.inst.deathValues[4] = (120 - ScoreTracker.timeRemain).ToString("0");
            //TODO: Get the value of 120 above dynamically
            GameManager.inst.Send("deathTracker");
        }
        // else{
        //     if (flag == 1){
        //     GameManager.inst.Send(tp);
        //     }
        // }


        Invoke("Restart", (float)0.25);
    }

    void Restart()
    {
        gameOverScreen.Setup();
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        Destroy(ObjectMusic);
    }

    void Jump()
    {
        // Check if we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        // If we are, jump
        if (isGrounded)
        {
            jump_sound.Play();
            rb.AddForce(Vector3.up * jumpForce);
        }

    }

    
}
