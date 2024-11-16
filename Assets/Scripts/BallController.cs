using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // For player movement
    private float horizontalInput;
    public float jumpForce = 10f;
    public float speed = 25f;

    // For collision and keeping the player from double jumping
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Vector2 boxSize;
    private float castDistance;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(horizontalInput * speed, 0), ForceMode2D.Force);

        // Jumping mechanic
        if (Input.GetKeyDown(KeyCode.W) && isOnGround())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Check if the ball is grounded using a boxcast
    public bool isOnGround()
    {
        // Dynamically calculate the box size based on the ball's scale
        boxSize.x = transform.localScale.x * 0.1f;
        boxSize.y = transform.localScale.y * 0.3f;
        castDistance = transform.localScale.y * 0.5f;

        // Get the local position for the bottom of the ball, ignoring rotation
        Vector2 groundCheckPosition = new Vector2(transform.position.x, transform.position.y - (transform.localScale.y / 2));

        // Perform a BoxCast to check if the ball is touching the ground
        return Physics2D.BoxCast(groundCheckPosition, boxSize, 0, Vector2.down, castDistance, groundLayer);
    }

    // Visualize the ground check area in the Scene view
    private void OnDrawGizmos()
    {
        // Dynamically calculate the box size based on the ball's scale
        boxSize.x = transform.localScale.x * 0.1f;
        boxSize.y = transform.localScale.y * 0.3f;
        castDistance = transform.localScale.y * 0.5f;

        // Visualize the ground check position (bottom of the ball)
        Vector2 groundCheckPosition = new Vector2(transform.position.x, transform.position.y - (transform.localScale.y / 2));

        // Draw the gizmo to visualize the boxcast area
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPosition, boxSize);
    }
}
