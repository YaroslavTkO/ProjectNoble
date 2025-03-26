using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MineGeneration : MonoBehaviour
{
    public Transform player;
    public float spawnRate = 0.5f;
    public float spawnDistance = 7f;
    public List<GameObject> minePrefabs;

    public GameObject currentMine;

    private float screenLeft;
    private float screenRight;

    private void Start()
    {
        screenLeft = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        screenRight = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        InvokeRepeating(nameof(SpawnMine), 0f, 2f);
    }

    void SpawnMine()
    {

        if (currentMine == null && Random.value < spawnRate)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(screenLeft, screenRight), player.position.y + 7f);

            currentMine = Instantiate(minePrefabs[Random.Range(0, minePrefabs.Count)], spawnPosition, Quaternion.identity);
        }

    }

    void DestroyMine()
    {
        if (currentMine != null && player.position.y > currentMine.transform.position.y + 10) {
            Destroy(currentMine);
        }

    }
    private void Update()
    {
        DestroyMine();
    }
}
