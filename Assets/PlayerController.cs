using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;

    private bool isSprinting = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if player is pressing the shift key to sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private void FixedUpdate()
    {
        // Calculate movement direction based on WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Set movement speed based on whether the player is sprinting or not
        float speed = isSprinting ? sprintSpeed : walkSpeed;

        // Move the player in the calculated direction and speed
        rb.MovePosition(rb.position + movementDirection * speed * Time.fixedDeltaTime);
    }
}
