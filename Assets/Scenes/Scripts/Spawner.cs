
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    public float rangeX = 12f;
    public float rangeZ = 12f;

    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnCoin();
            spawnTimer = 0f;
        }
    }

    void SpawnCoin()
    {
        float x = Random.Range(-rangeX, rangeX);
        float z = Random.Range(-rangeZ, rangeZ);

        Vector3 spawnPosition = new Vector3(x, 3.5f, z);

        GameObject spawnedCoin = Instantiate(
            coinPrefab,
            spawnPosition,
            Quaternion.identity
        );

        Debug.Log("Spawned coin: " + spawnedCoin.name);
    }
}
