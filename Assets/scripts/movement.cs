using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator anima;

    public float moveSpeed = 5f;

    float horizontalMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb2d.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
}
