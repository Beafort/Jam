using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveDiretion;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.linearVelocity = moveDiretion * moveSpeed;    
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDiretion = context.ReadValue<Vector2>();
    }
}
