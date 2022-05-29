using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController2D : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpSpeed = 4f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    private bool isTouchingGround;
    private float direction = 0f;
    private Rigidbody2D player;
    private Animator playerAnimation;
    public bool facingRight = false;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        // Player movement
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // ground check
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(speed * direction, player.velocity.y);
            transform.localScale = new Vector2(2f, 2f); // scale sets player to face right
            facingRight = true;
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(speed * direction, player.velocity.y);
            transform.localScale = new Vector2(-2f, 2f); // scale sets player to face left
            facingRight = false;
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);    
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x)); // makes velocity positive regardless of direction
        playerAnimation.SetBool("OnGround", isTouchingGround); // checks if on ground using previously established variable
    }
}
// https://www.youtube.com/watch?v=wkKsl1Mfp5M 2d shooting
// Daniel Wood unity 2d platform tutorials
// https://www.youtube.com/watch?v=n39-j7qfvWU2D Scrolling background
// https://www.youtube.com/watch?v=HVCsg_62xYw player animations
// https://www.youtube.com/watch?v=hkaysu1Z-N8 player animations brackeys

