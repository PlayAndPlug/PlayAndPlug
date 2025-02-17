using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform groundCheckPoint;
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject panel;

    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float deceleration = 50f;
    private float horizontalDirection;
    private bool isFacingRight = true;

    [Header("Salto")]
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float fallGravityMultiplier = 3f;
    [SerializeField] private float jumpCutMultiplier = 2f;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private bool enableDoubleJump = true;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.4f, 0.1f);
    private float coyoteTimeCounter;
    private bool isGrounded;
    private bool canJump => (coyoteTimeCounter > 0f || (enableDoubleJump && hasDoubleJump));
    private bool hasDoubleJump = false;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        CheckGrounded();
        UpdateCoyoteTime();
        HandleJump();
        UpdateDirection();
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyGravityMultiplier();
    }

    private void CheckGrounded()
    {
        if (groundCheckPoint != null)
        {
            bool wasGrounded = isGrounded;

            RaycastHit2D hit = Physics2D.BoxCast(
                groundCheckPoint.position,
                groundCheckSize,
                0f,
                Vector2.down,
                0.1f,
                groundLayer
            );

            isGrounded = hit.collider != null && Mathf.Abs(hit.normal.y) > 0.9f;

            if (isGrounded && !wasGrounded)
                hasDoubleJump = true;
        }
    }

    private void UpdateCoyoteTime()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            hasDoubleJump = true;
        }
        else
            coyoteTimeCounter -= Time.deltaTime;
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            if (coyoteTimeCounter > 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                coyoteTimeCounter = 0f;
            }
            else if (hasDoubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                hasDoubleJump = false;
            }
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
    }

    private void ApplyMovement()
    {
        float targetSpeed = horizontalDirection * moveSpeed;
        float speedDiff = targetSpeed - rb.linearVelocity.x;
        float accelerationRate = Mathf.Abs(targetSpeed) > 0.01f ? acceleration : deceleration;

        rb.AddForce(speedDiff * accelerationRate * Vector2.right);

        if (Mathf.Abs(rb.linearVelocity.x) > moveSpeed)
            rb.linearVelocity = new Vector2(moveSpeed * Mathf.Sign(rb.linearVelocity.x), rb.linearVelocity.y);

        if (Mathf.Abs(horizontalDirection) < 0.01f && Mathf.Abs(rb.linearVelocity.x) < 0.1f)
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
    }

    private void ApplyGravityMultiplier()
    {
        if (rb.linearVelocity.y < 0)
            rb.gravityScale = fallGravityMultiplier;
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
            rb.gravityScale = jumpCutMultiplier;
        else
            rb.gravityScale = 1f;
    }

    private void UpdateDirection()
    {
        if (horizontalDirection > 0 && !isFacingRight)
            Flip();
        else if (horizontalDirection < 0 && isFacingRight)
            Flip();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void UpdateAnimations()
    {
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
        animator.SetFloat("HorizontalVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("HasDoubleJump", hasDoubleJump);
    }

    private void OnDrawGizmos()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision){
        
        
    }
}