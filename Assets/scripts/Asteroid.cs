using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyedParticles;
    [SerializeField] List<Sprite> spriteList;
    [SerializeField] AudioClip destroyAudio;
    public int size = 3;

    public GameManager gameManager;


    private void Start()
    {
        transform.localScale = 0.5f * size * Vector3.one;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        float spawnSpeed = Random.Range(4f - size, 5f - size);
        rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);

       GameManager.instance.asteroidCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameManager.instance.asteroidCount--;
            SFXManager.Instance.PlaySoundFXClip(destroyAudio, transform, 1f);
            Destroy(collision.gameObject);

            if (size > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Asteroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
                    newAsteroid.size = size - 1;
                    newAsteroid.gameManager = gameManager;

                    if (spriteList.Count > 0 && newAsteroid.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
                    {
                        int randomIndex = Random.Range(0, spriteList.Count);
                        sr.sprite = spriteList[randomIndex];
                    }
                }
            }

            GeralManager.instance.pontos += 10 * size;

            // Spawn particles on destruction.
            Instantiate(destroyedParticles, transform.position, Quaternion.identity);

            // Destroy this asteroid.
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.asteroidCount--;
            GeralManager.instance.pontos -= 10 * size;
            SFXManager.Instance.PlaySoundFXClip(destroyAudio, transform, 1f);
            Instantiate(destroyedParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
