
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float rangeX = 12f;
    public float rangeZ = 12f;

    public void SpawnCoin()
    {
        float x = Random.Range(-rangeX, rangeX);
        float z = Random.Range(-rangeZ, rangeZ);

        Vector3 spawnPosition = new Vector3(x, 3.5f, z);

        Instantiate(
            coinPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}
