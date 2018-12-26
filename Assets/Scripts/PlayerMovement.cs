using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // playerInput
    public int playerNumber = 1;
    public float maxSpeed = 7;


    private string xMovementAxisName;
    private float movementInputValue;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 move;
    private bool facingRight = true;

    // Jumping variables
    public float jumpForce = 15;
    public Transform groundCheck;
    public float checkRadius = 0.25f;
    public LayerMask whatIsGround;
    private string jumpAxisName;
    private bool isGrounded;

    // Crouching
    private string crouchInputName;
    private bool crouching = false;
    private CircleCollider2D circleC2d;
    public float crouchSpeedModifier = 0.5f;

    // Dashing
    private string dashInputName;
    public float dashForce = 12;
    public float dashCooldown = .5f;
    private float dashTimer;
    private bool dashing;


    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circleC2d = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        jumpAxisName = "Jump" + playerNumber;
        xMovementAxisName = "Horizontal" + playerNumber;
        crouchInputName = "Crouch" + playerNumber;
        dashInputName = "Dash" + playerNumber;
    }

    void FixedUpdate()
    {
        //Jumping
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetButtonDown(jumpAxisName) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded)
        {

            // Crouching
            if (Input.GetButton(crouchInputName) && movementInputValue == 0)
            {
                crouching = true;
                circleC2d.enabled = false;
            }
            else
            {
                crouching = false;
                circleC2d.enabled = true;
            }
        }

        // Moving along the x-Axis
        move = Vector2.zero;
        move.x = movementInputValue;
        if (!dashing)
        {
            rb.velocity = new Vector2(move.x * maxSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(move.x * dashForce, rb.velocity.y);
        }
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


        animator.SetBool("dashing", dashing);

        // dashing
        if (Input.GetButtonDown(dashInputName) && !dashing)
        {
            animator.SetTrigger("dash");
            dashing = true;
            dashTimer = dashCooldown;
        }

        if (dashing)
        {

            if (!isGrounded || rb.velocity.x == 0)
            {
                dashing = false;
            }
            if (dashTimer > 0)
            {
                dashTimer -= Time.deltaTime;
            }
            else
            {
                dashing = false;
            }
        }


    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}