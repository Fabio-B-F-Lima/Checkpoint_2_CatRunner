using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (
            other.CompareTag("Obstacles") ||
            other.CompareTag("Coin")
        )
        {
            Destroy(other.gameObject);
        }
    }
}