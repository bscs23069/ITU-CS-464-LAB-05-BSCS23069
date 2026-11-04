
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject coinPrefab;
    public GameObject normalCoinPrefab;
    public GameObject redCoinPrefab;
    public GameObject blueCoinPrefab;
    public float circleRadius = 5f;
    public float rangeX = 12f;
    public float rangeZ = 12f;
    public float normalCoinY = 3.5f;

    public int numberOfBlueCoins = 50;
    public float blueCoinY = 0.5f;

    private int normalCoinsCollected = 0;
    private int redCoinScore;

    private int blueCoinsCollected = 0;

    private bool redCoinSpawned = false;
    private bool bonusStarted = false;
    private bool bonusCompleted = false;


    private void Start()
    {
        // Random integer from 1 to 10, inclusive.
        redCoinScore = Random.Range(1, 11);

        Debug.Log(
            "Red coin appears after " +
            redCoinScore + " normal coin(s)."
        );
    }

    public void NormalCoinCollected()
    {
        normalCoinsCollected++;

        // Spawn the red coin at the chosen threshold.
        if (!redCoinSpawned &&
            normalCoinsCollected >= redCoinScore)
        {
            redCoinSpawned = true;
            SpawnSingleCoin(redCoinPrefab, normalCoinY);
        }
        else if (!bonusStarted || bonusCompleted)
        {
            // Spawn only one replacement normal coin.
            SpawnSingleCoin(
                normalCoinPrefab,
                normalCoinY
            );
        }
    }

    private void SpawnSingleCoin(
        GameObject prefab,
        float yPosition)
    {
        if (prefab == null)
        {
            Debug.LogError(
                "A coin prefab is missing in the Spawner Inspector."
            );
            return;
        }

        float x = Random.Range(-rangeX, rangeX);
        float z = Random.Range(-rangeZ, rangeZ);

        Vector3 position = new Vector3(
            x,
            yPosition,
            z
        );

        Instantiate(
            prefab,
            position,
            Quaternion.identity
        );
    }

    public void RedCoinCollected(Vector3 playerPosition)
    {
        if (bonusStarted)
            return;

        if (blueCoinPrefab == null)
        {
            Debug.LogError(
                "Blue Coin Prefab is not assigned."
            );
            return;
        }

        bonusStarted = true;
        blueCoinsCollected = 0;

        // Create 50 blue coins around the player.
        for (int i = 0; i < numberOfBlueCoins; i++)
        {
            float angle =
                i * (360f / numberOfBlueCoins) *
                Mathf.Deg2Rad;

            Vector3 offset = new Vector3(
                Mathf.Cos(angle) * circleRadius,
                blueCoinY,
                Mathf.Sin(angle) * circleRadius
            );

            Instantiate(
                blueCoinPrefab,
                playerPosition + offset,
                Quaternion.identity
            );
        }

        // Show the hidden bonus counter.
        BonusCoinUI ui =
            FindFirstObjectByType<BonusCoinUI>();

        if (ui != null)
        {
            ui.ShowBonusCounter();
        }
    }

    public void BlueCoinCollected()
    {
        if (!bonusStarted || bonusCompleted)
            return;

        blueCoinsCollected++;

        BonusCoinUI ui =
            FindFirstObjectByType<BonusCoinUI>();

        if (ui != null)
        {
            ui.AddBonusCoin();
        }

        // Finish the bonus round after all 50 are collected.
        if (blueCoinsCollected >= numberOfBlueCoins)
        {
            bonusCompleted = true;

            // Resume the normal coin cycle.
            SpawnSingleCoin(
                normalCoinPrefab,
                normalCoinY
            );

            if (GameManager.instance != null)
            {
                GameManager.instance.BonusRoundCompleted();
            }
        }
    }
    //public void SpawnCoin()
    //{

    //    float x = Random.Range(-rangeX, rangeX);
    //    float z = Random.Range(-rangeZ, rangeZ);

    //    Vector3 spawnPosition = new Vector3(x, 3.5f, z);

    //    Instantiate(
    //        coinPrefab,
    //        spawnPosition,
    //        Quaternion.identity
    //    );
    //}
}
