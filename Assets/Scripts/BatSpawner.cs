using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawners;
    [SerializeField]
    private GameObject batPrefab;

    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 3.0f;

    private bool spawning = true;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            Instantiate(batPrefab, spawners[Random.Range(0, spawners.Count)].position, Quaternion.identity);
        }
    }

    public void StartSpawning()
    {
        spawning = true;
    }

    public void StopSpawning()
    {
        spawning = false;
    }
}
