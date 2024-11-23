using UnityEditor.Rendering;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // For player movement
    private float horizontalInput;
    private float jumpTimer;
    public float jumpForce = 10f;
    public float speed = 5f;
    public float maxVelocity = 8f;

    // For collision and keeping the player from double jumping
    private Rigidbody2D rb;
    private bool isGrounded;
    private float raycastDistance;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer++;
        
        horizontalInput = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector2(horizontalInput * speed, 0), ForceMode2D.Force);
        
        raycastDistance = transform.localScale.y * 0.6f;
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);

        // Jumping mechanic
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && jumpTimer > 120)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpTimer = 0;
        }
    }

    // Visualize the ground check area in the Scene view
    private void OnDrawGizmos()
    {
        // Draw the gizmo to visualize the raycast area
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastDistance);
    }
}
