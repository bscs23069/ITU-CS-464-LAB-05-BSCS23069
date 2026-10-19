
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected!");

            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(1);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("GameManager instance is missing!");
            }
        }
    }
}
