using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator anima;

    public float moveSpeed = 5f;

    float horizontalMovement;
    public bool parado = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (parado == false)
        {
        rb2d.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb2d.linearVelocity.y);
        }
    }

    public void parar()
    {
        parado = true;
    }

    public void andar()
    {
        parado = false;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
}
