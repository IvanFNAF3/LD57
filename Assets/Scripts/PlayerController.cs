using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float speedLimit = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpLimit = 30f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isFacingRight = true;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Проверка нахождения на земле
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        // Обработка прыжка
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Движение игрока
        Move();
    }

    private void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Разворот персонажа в направлении движения
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Визуализация зоны проверки земли в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    public void SpeedUp(float delta)
    {
        if(moveSpeed <= 10f)
        {
            moveSpeed += delta;
        }
    }

    public void JumpUp(float delta)
    {
        if (jumpForce <= jumpLimit)
        {
            jumpForce += delta;
        }
    }

    public void Reset()
    {
        jumpForce = 8.5f;
        moveSpeed = 3.5f;
    }
}