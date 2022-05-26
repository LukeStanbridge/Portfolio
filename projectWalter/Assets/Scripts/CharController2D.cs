using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController2D : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    private bool isTouchingGround;
    private float direction = 0f;
    private Rigidbody2D player;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Player movement
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // ground check
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(speed * direction, player.velocity.y);
            // set running animation
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(speed * direction, player.velocity.y);
            // set running animation
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
            // set idle animation
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            // set jump animation
        }
    }
}
// https://www.youtube.com/watch?v=wkKsl1Mfp5M 2d shooting
// Daniel Wood unity 2d platform tutorials
