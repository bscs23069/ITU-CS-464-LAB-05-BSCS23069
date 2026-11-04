
using UnityEngine;

public class Coin : MonoBehaviour
{
    public enum CoinType { Normal, Red, Blue }
    public CoinType coinType = CoinType.Normal;

    public float rotationSpeed = 90f;
    private bool collected = false;

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Coin collected!");

    //        if (GameManager.instance != null)
    //        {
    //            GameManager.instance.AddScore(1);

    //        }
    //        Spawner spawner = FindFirstObjectByType<Spawner>();

    //        if (spawner != null)
    //        {
    //            spawner.SpawnCoin();
    //        }

    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Prevent the same coin being collected twice.
        if (collected)
            return;

        collected = true;

        if (GameManager.instance != null)
            GameManager.instance.AddScore(1);

        //// Display the floating +1 effect.
        //FloatingScore popup = FindFirstObjectByType<FloatingScore>();
        //if (popup != null)
        //    popup.Show(other.transform);

        Spawner spawner = FindFirstObjectByType<Spawner>();

        if (spawner != null)
        {
            if (coinType == CoinType.Normal)
            {
                spawner.NormalCoinCollected();
            }
            //else if (coinType == CoinType.Red)
            //{
            //    spawner.RedCoinCollected(other.transform.position);
            //}
            //else if (coinType == CoinType.Blue)
            //{
            //    spawner.BlueCoinCollected();
            //}
            else if (coinType == CoinType.Red)
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.RedCoinCollected();
                }

                spawner.RedCoinCollected(
                    other.transform.position
                );
            }
            else if (coinType == CoinType.Blue)
            {
                spawner.BlueCoinCollected();
            }

        }

        Destroy(gameObject);
    }


}
