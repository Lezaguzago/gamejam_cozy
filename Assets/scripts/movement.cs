using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Yarn.Unity;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator anima;

    public float moveSpeed = 5f;
    public float moveEscada = 5f;
    float horizontalMovement;
    float verticalMovement;
    public bool parado = false;
    [SerializeField] private bool escalando;
    [SerializeField]private bool escada;

    [SerializeField] private SpriteRenderer sr;

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

        if (escada == true && Mathf.Abs(verticalMovement) > 0)
        {
            escalando = true;
        }

        if (horizontalMovement > 0)
        {
            sr.flipX = true;
        }

        else if (horizontalMovement < 0)
        {
            sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        if (escalando == true)
        {
            rb2d.gravityScale = 0f;
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, verticalMovement * moveEscada);
            
        }

        else
        {
            rb2d.gravityScale = 1f;
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
        verticalMovement = context.ReadValue<Vector2>().y;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("escada"))
        {
            escada = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        escada = false;
        escalando = false;
    }
}
