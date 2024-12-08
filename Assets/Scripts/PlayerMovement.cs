using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 4f;
    public float maxSpeed = 12f;
    public float acceleration = 2f;
    public float deceleration = 3f; // Rate at which speed decreases without input
    public float currentSpeed;

    public float jumpingPower = 16f;
    public bool isFacingRight = true;
    public bool isGrounded;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float horizontal;

    void Start()
    {
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        isGrounded = IsGrounded();
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }
        else
        {
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, baseSpeed);
        }

        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);
        Flip();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}