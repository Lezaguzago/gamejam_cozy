using System.Drawing;
using UnityEngine;

public class Help : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        float spawnSpeed = Random.Range(1f, 2f);
        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GeralManager.instance.saved = true;
            GeralManager.instance.lifeSaveds += 1;
            GameManager.instance.isSpawned = false;
            Destroy(gameObject);
        }
    }
}
