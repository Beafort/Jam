using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public Vector2 MoveDirection { get; private set; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        rb.linearVelocity = MoveDirection * moveSpeed;    
    }

    public void Move(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", MoveDirection.x);
        animator.SetFloat("InputY", MoveDirection.y);
        if (MoveDirection.x != 0)
        {
            spriteRenderer.flipX = MoveDirection.x < 0;
        }
        if (context.canceled)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);

            if (MoveDirection != Vector2.zero)
            {
                animator.SetFloat("LastInputX", MoveDirection.x);
                animator.SetFloat("LastInputY", MoveDirection.y);
            }
        }
        
    }
}
