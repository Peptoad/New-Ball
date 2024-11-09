using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }
    //for player movement
    private float horizontalInput;
    public float jumpForce = 10;
    public float speed = 5;
    //for collision and keeping the player from double jumping
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    // Update is called once per frame
    void Update()
    {


        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isOnGround() == true)
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //Debug.Log("jump");

        }
    }
    public bool isOnGround()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);

    }
}