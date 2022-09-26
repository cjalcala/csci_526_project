using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPlayerMovement : MonoBehaviour
{
    public float speed = 10;
    bool alive = true;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier = 1.25f;
    public float jumpForce = 600f;
    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(transform.position.y < -5) 
        {
            Die();
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), transform.position.y, transform.position.z);

    }

    private void FixedUpdate() 
    {
        if(!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    public void Die()
    {
        alive = false;        
        Invoke("Restart", 1);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2)+0.1f, groundMask);

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        
    }

    void Restart ()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
