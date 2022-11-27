using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player_Controller : MonoBehaviour
{
    // Variables
    [Header("COMPONENTS")]
    public Animator anim;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;

    [Space(15)]
    [Header("MOVEMENT PARAMS")]
    public float moveSpeed = 1f;
    public float movementX;
    public float jumpForce = 2.5f;
    public bool doubleJump;

    [Space(15)]
    [Header("LAYER MASKS")]
    public LayerMask groundLayer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        // Input
        GetInput();
    }

    void Update()
    {
        // Calling the movement method
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                Jump();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (doubleJump)
                    {
                        DoubleJump();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Method for getting the Inputs
    /// </summary>
    public void GetInput()
    {
        movementX = Input.GetAxis("Horizontal");
    }

    #region PLAYER MOVEMENT & FLIP

    /// <summary>
    /// Method for the player movement and the anims
    /// </summary>
    public void Movement()
    {
        rb.velocity = new Vector2(movementX * moveSpeed, rb.velocity.y);
        
        // Set animator parameters
        anim.SetBool("Walk", movementX != 0);
        anim.SetBool("Grounded", IsGrounded());
        
        // Calling the flip method
        FlipPlayer();
    }

    /// <summary>
    /// Method for flip player when moving left
    /// </summary>
    public void FlipPlayer()
    {
        if (movementX > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (movementX < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    #endregion

    #region PLAYER JUMP

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down,
            0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    /// <summary>
    /// Method for jumpìng only one time
    /// </summary>
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
        // Set animator parameters
        anim.SetTrigger("Jump");
    }
    
    /// <summary>
    /// Method for jumpìng a second time
    /// </summary>
    public void DoubleJump()
    {
        jumpForce += 0.5f;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
        doubleJump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            doubleJump = true;
            jumpForce = 2.5f;
        }
    }

    #endregion
}
