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
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private HealthManager healthManager;

    [Space(15)]
    [Header("MOVEMENT PARAMS")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float movementX;
    [SerializeField] private float jumpForce = 2.5f;
    [SerializeField] private bool doubleJump;

    [Space(15)]
    [Header("LAYER MASKS")]
    [SerializeField] private LayerMask groundLayer;

    [Space(15)]
    [Header("AUDIO CLIPS")]
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip damagedSFX;

    void Awake()
    {
        // Getting the necessary components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        healthManager = GetComponent<HealthManager>();
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

        // If we press Space and player is grounded, he can jump
        // If we press Space and player isn't grounded, he can press Space to make an other jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.PlaySound(jumpSFX);
            
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
    /// Method for getting the movement Inputs
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

    /// <summary>
    /// Method for knowing if player is touching the floor or not
    /// </summary>
    /// <returns>If player touches the floor, returns a non null raycast</returns>
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
        // If player touches the Ground, he can make a double jump and the jumpForce changes
        if (other.gameObject.CompareTag("Ground"))
        {
            doubleJump = true;
            jumpForce = 2.5f;
        }
    }

    #endregion
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player triggers with tag Spike, plays the damaged SFX
        if (other.gameObject.CompareTag("Spike"))
        {
            if (healthManager.actualHealth != 0)
            {
                AudioManager.instance.PlaySound(damagedSFX);
            }
        }
    }
}
