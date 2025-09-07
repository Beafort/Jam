using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Vector2 MoveDiretion { get; private set; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.linearVelocity = MoveDiretion * moveSpeed;    
    }

    public void Move(InputAction.CallbackContext context)
    {
        MoveDiretion = context.ReadValue<Vector2>();
    }
}
