using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    Rigidbody2D theRB;
    Vector2 initialPosition;
    [SerializeField] float speed = 5;
    [SerializeField] float floatStrength = .1f;

    void Start()
    {
        theRB = this.GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * floatStrength;
        Vector3 position = new Vector2(0, newY) + initialPosition;
        theRB.MovePosition(position);
    }
}
