using UnityEngine;

public class BallController : MonoBehaviour
{
    // For player movement
    private float horizontalInput;
    private float jumpTimer;
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
        jumpTimer++;
        boxSize.x = transform.localScale.x * 0.1f;
        boxSize.y = transform.localScale.y * 0.3f;
        castDistance = transform.localScale.y * 0.5f;

        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(horizontalInput * speed, 0), ForceMode2D.Force);

        // Jumping mechanic
        if (Input.GetKeyDown(KeyCode.W) && isOnGround() && jumpTimer > 120)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpTimer = 0;
        }
    }

    // Check if the ball is grounded using a boxcast
    private bool isOnGround()
    {
        // Get the local position for the bottom of the ball, ignoring rotation
        Vector3 groundCheckPosition = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z);

        // Perform a BoxCast to check if the ball is touching the ground
        return Physics2D.BoxCast(groundCheckPosition, boxSize, 0, -transform.up, castDistance, groundLayer);
    }

    // Visualize the ground check area in the Scene view
    private void OnDrawGizmos()
    {
        // Visualize the ground check position (bottom of the ball)
        Vector3 groundCheckPosition = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z);

        // Draw the gizmo to visualize the boxcast area
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPosition, boxSize);
    }
}
