using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class spaceShipScript : MonoBehaviour
{
    [SerializeField] LevelLoaderScript levelLoader;

    [SerializeField] float shipSpeed = -10f;
    [SerializeField] float maxShipSpeed = -10f;
    [SerializeField] Vector2 whereLook;
    [SerializeField] Camera camera;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] float bulletSpeed = 10f;

    Player_actions input;

    Rigidbody2D rb;

    private void Awake()
    {
        input = new Player_actions();
        input.SpaceShip.Look.performed += ShipRotation;
        input.SpaceShip.ShootInteract.performed += ShipFire;
        input.SpaceShip.GoBack.performed += Inside;
    }

    private void OnEnable()
    {
        input.SpaceShip.Look.performed += ShipRotation;
        input.SpaceShip.ShootInteract.performed += ShipFire;
        input.SpaceShip.GoBack.performed += Inside;
        input.Enable();
    }
    private void OnDisable()
    {
        input.SpaceShip.Look.performed -= ShipRotation;
        input.SpaceShip.ShootInteract.performed -= ShipFire;
        input.SpaceShip.GoBack.performed -= Inside;
        input.Disable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookInput = input.SpaceShip.Look.ReadValue<Vector2>();
        if (Mouse.current != null && Mouse.current.position.ReadValue() != Vector2.zero)
        {
            Vector3 mousePosition = camera.ScreenToWorldPoint(new Vector3(lookInput.x, lookInput.y, -camera.transform.position.z));

            Vector2 mouse = mousePosition - transform.position;

            RotateDirection(mouse);
        }
        
        if (Gamepad.current != null)
        {
            Vector2 stick = Gamepad.current.leftStick.ReadValue();

            if (stick.magnitude > 0.1f)
            {
                RotateDirection(stick);
            }
        }
    }

    void RotateDirection(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f)
            return;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ShipRotation(InputAction.CallbackContext ctx)
    {
        whereLook = ctx.ReadValue<Vector2>();
    }
    void ShipFire(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            rb.AddForce(shipSpeed * transform.right);
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxShipSpeed);
            Rigidbody2D fire = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            fire.AddForce(bulletSpeed * transform.right, ForceMode2D.Impulse);
        }
    }

    void Inside(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            levelLoader.LoadNextLevel(1);
;
        }
    }
}
