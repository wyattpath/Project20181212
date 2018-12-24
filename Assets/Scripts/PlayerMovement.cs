using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // playerInput
    public int playerNumber = 1;
    public float jumpForce = 15;
    public float maxSpeed = 7;


    private string xMovementAxisName;

    private float movementInputValue;
    private float speed;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 move;
    private bool facingRight = true;

    // Jumping variables
    private string jumpAxisName;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius = 0.25f;
    public LayerMask whatIsGround;

    // Crouching
    private string crouchInputName;
    private bool crouching = false;
    private CircleCollider2D circleC2d;
    public float crouchSpeedModifier = 0.5f;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circleC2d = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        jumpAxisName = "Jump" + playerNumber;
        xMovementAxisName = "Horizontal" + playerNumber;
        crouchInputName = "Crouch" + playerNumber;
    }

    void FixedUpdate()
    {
        //Jumping
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetButtonDown(jumpAxisName) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // Crouching
        if (Input.GetButton(crouchInputName) && isGrounded)
        {
            crouching = true;
            circleC2d.enabled = false;
        }
        else
        {
            crouching = false;
            circleC2d.enabled = true;
        }

        // Moving along the x-Axis
        move = Vector2.zero;
        move.x = movementInputValue;
        speed = crouching ? move.x * maxSpeed * crouchSpeedModifier : move.x * maxSpeed;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        movementInputValue = Input.GetAxis(xMovementAxisName);

        // facing right
        if (move.x > 0.01f && !facingRight)
        {
            //transform.localScale = new Vector3(1,1,1);
            Flip();
        }
        // facing left
        else if (move.x < -0.01f && facingRight)
        {
            //transform.localScale = new Vector3(-1,1,1);
            Flip();
        }

        // Animates walking
        animator.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        animator.SetBool("grounded", isGrounded);

        // Animates crouching
        animator.SetBool("crouching", crouching);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
