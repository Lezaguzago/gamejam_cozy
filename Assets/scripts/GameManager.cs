using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Asteroid asteroidPrefab;
    [SerializeField] private Help helpPrefab;
    public int asteroidCount = 0;
    int willSpawn;
    private int level = 0;
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (asteroidCount == 0)
        {
            willSpawn = Random.Range(1, 5);
            // Increase the level.
            level++;

            // Spawn the correct number for this level.
            // 1=>4, 2=>6, 3=>8, 4=>10 ...
            int numAsteroids = 1 + level;
            for (int i = 0; i < numAsteroids; i++)
            {
                SpawnAsteroid();
            }
        }
    }

    private void SpawnAsteroid()
    {
        // How far along the edge.
        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPosition = Vector2.zero;

        // Which edge.
        int edge = Random.Range(0, 4);
        if (edge == 0)
        {
            viewportSpawnPosition = new Vector2(offset, 0);
        }
        else if (edge == 1)
        {
            viewportSpawnPosition = new Vector2(offset, 1);
        }
        else if (edge == 2)
        {
            viewportSpawnPosition = new Vector2(0, offset);
        }
        else if (edge == 3)
        {
            viewportSpawnPosition = new Vector2(1, offset);
        }

        // Create the asteroid.
        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        Asteroid asteroid = Instantiate(asteroidPrefab, worldSpawnPosition, Quaternion.identity);
        asteroid.gameManager = this;

        if(willSpawn > 2)
        {
            Vector2 worldSpawnPos = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
            Help help = Instantiate(helpPrefab, worldSpawnPosition, Quaternion.identity);
        }
        willSpawn = 0;
    }

}
