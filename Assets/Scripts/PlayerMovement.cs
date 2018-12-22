using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // playerInput
    public int playerNumber = 1;
    private string jumpAxisName;
    private string xMovementAxisName;
    private float movementInputValue;
    private float turnInputValue;

    public float maxSpeed = 7;
    public float jumpForce = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 move;

    // Jumping variables
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private void Start()
    {
        jumpAxisName = "Jump" + playerNumber;
        xMovementAxisName = "Horizontal" + playerNumber;
    }


    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
		//Jumping
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetButtonDown(jumpAxisName) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

		// Moving along the x-Axis
        move = Vector2.zero;
        move.x = movementInputValue;
        rb.velocity = new Vector2(move.x * maxSpeed, rb.velocity.y);



    }

    // Update is called once per frame
    void Update()
    {
        movementInputValue = Input.GetAxis(xMovementAxisName);

        // flips Sprite
        if (move.x > 0.01f)
        {
                transform.localScale = new Vector3(1,1,1);

            


        }
        else if (move.x < -0.01f)
        {
                transform.localScale = new Vector3(-1,1,1);
            
        }

        // Animates walking
        animator.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        animator.SetBool("grounded", isGrounded);
    }
}
