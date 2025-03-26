using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public List<GameObject> platformPrefabs;
    public List<float> probabilities;
    public float spawnInterval = 2f;

    public int initialPlatforms = 5;
    public float despawnHeight = -5f;

    private float highestY;
    private float minX = -2.5f, maxX = 2.5f;
    private Queue<GameObject> platforms = new Queue<GameObject>();

    private Transform cameraTransform;

    void Start()
    {
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
        minX = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        maxX = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        cameraTransform = Camera.main.transform;
    }

    GameObject GetPlatform()
    {
        float randomValue = Random.Range(0f, 1f);
        float cumulativeProbability = 0f;

        for (int i = 0; i < platformPrefabs.Count; i++)
        {
            cumulativeProbability += probabilities[i];

            if (randomValue <= cumulativeProbability)
            {
                return platformPrefabs[i];
            }
        }

        return platformPrefabs[platformPrefabs.Count - 1];
    }

    void SpawnPlatform()
    {
        float randomX = Random.Range(minX, maxX);
        float newY = highestY + spawnInterval;

        Vector3 spawnPosition = new Vector3(randomX, newY, 0);

        var platform = GetPlatform();
        if (platform == platformPrefabs[1] || platform == platformPrefabs[3])
            spawnPosition.x = 0;
        GameObject newPlatform = Instantiate(platform, spawnPosition, Quaternion.identity);
        platforms.Enqueue(newPlatform);

        highestY = newY;
    }

    void Update()
    {
        if (cameraTransform.position.y + 5f > highestY)
        {
            SpawnPlatform();
        }


        if (platforms.Count > 0 && platforms.Peek().transform.position.y < cameraTransform.position.y + despawnHeight)
        {
            Destroy(platforms.Dequeue());
        }
    }
}
