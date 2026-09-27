using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Asteroid asteroidPrefab;
    [SerializeField] Help helpPrefab;
    [SerializeField] List<Sprite> spriteList;
    public bool isSpawned = false;
    public int asteroidCount = 0;
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
            level++;

            int numAsteroids = 1 + level;
            for (int i = 0; i < numAsteroids; i++)
            {
                SpawnAsteroid();
            }
        }
    }

    private void SpawnAsteroid()
    {
        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPosition = Vector2.zero;

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

        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        Asteroid asteroid = Instantiate(asteroidPrefab, worldSpawnPosition, Quaternion.identity);
        asteroid.gameManager = this;

        if (spriteList.Count > 0 && asteroid.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
        {
            int randomIndex = Random.Range(0, spriteList.Count);
            sr.sprite = spriteList[randomIndex];
        }

        if (level%2 == 0 && !isSpawned && GeralManager.instance.lifeSaveds < 5)
        {
            isSpawned = true;
            Vector2 worldSpawnPos = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
            Help help = Instantiate(helpPrefab, worldSpawnPosition, Quaternion.identity);
        }
    }

}
