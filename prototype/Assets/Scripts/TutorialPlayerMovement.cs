using UnityEngine;

public class TutorialPlayerMovement : MonoBehaviour
{
    public float speed = 8;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier = 1.25f;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() 
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
}
