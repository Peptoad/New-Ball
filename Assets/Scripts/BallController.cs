using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //for player movement
    private float horizontalInput;
    public float jumpForce = 10;
    public float speed = 5;
    //for collision and keeping the player from double jumping
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

        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround() == true)
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //Debug.Log("jump");

        }
    }
    public bool isOnGround()
    {

        boxSize.x = (float)(transform.localScale.x * 0.1);
        boxSize.y = (float)(transform.localScale.y * 0.3);
        castDistance = (float)(transform.localScale.y * 0.5);

        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer);
    }
    private void OnDrawGizmos()
    {

        boxSize.x = (float)(transform.localScale.x * 0.1);
        boxSize.y = (float)(transform.localScale.y * 0.3);
        castDistance = (float)(transform.localScale.y * 0.5);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}