
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 90f;

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected!");

            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(1);
                
            }
            Spawner spawner = FindFirstObjectByType<Spawner>();

            if (spawner != null)
            {
                spawner.SpawnCoin();
            }

            Destroy(gameObject);
        }
    }
   
}
