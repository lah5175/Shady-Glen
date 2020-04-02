using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float originalSpeed = 12f;
    public float gravity = -19.62f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    
    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        float speed;

        // Causes Player to sprint if LShift is held down
        if (Input.GetKey(KeyCode.LeftShift)) speed = (float)(originalSpeed * 1.5);
        else speed = originalSpeed;

        // Creates a tiny invisible sphere at the bottom of the player that detects collisions to toggle gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If the sphere collides with the ground but is not entirely touching it, this will force them slightly downwards
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Gets the vector for where to move the player and then moves them in that direction
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
