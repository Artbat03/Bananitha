using System;
using System.Collections;
using System.Collections.Generic;
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
    }

    /// <summary>
    /// Method for getting the Inputs
    /// </summary>
    public void GetInput()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    }

    #region PLAYER MOVEMENT & FLIP

    /// <summary>
    /// Method for the player movement and the anims
    /// </summary>
    public void Movement()
    {
        rb.velocity = new Vector2(movementX * moveSpeed, rb.velocity.y * moveSpeed);
        
        // Set animator parameters
        anim.SetFloat("Speed", movementX);
        anim.SetBool("Walk", movementX != 0);
        
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
    /// Method for jumpìng
    /// </summary>
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        
        // Set animator parameters
        anim.SetBool("Grounded", IsGrounded());
    }

    #endregion
}
