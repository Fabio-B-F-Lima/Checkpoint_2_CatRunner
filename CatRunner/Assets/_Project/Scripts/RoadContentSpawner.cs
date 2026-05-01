using UnityEngine;

public class RoadContentSpawner : MonoBehaviour
{
    [Header("Obstáculos")]
    [SerializeField] private Transform[] obstaclePoints;
    [SerializeField] private GameObject[] obstacles;

    [Header("Moedas")]
    [SerializeField] private Transform[] coinPoints;
    [SerializeField] private GameObject[] coinPrefabs;

    public void GenerateContent()
    {
        SpawnObstacles();
        SpawnCoins();
    }

    void SpawnObstacles()
    {
        foreach (Transform point in obstaclePoints)
        {
            if (Random.value > 0.6f)
            {
                int index = Random.Range(0, obstacles.Length);

                Instantiate(
                    obstacles[index],
                    point.position,
                    obstacles[index].transform.rotation
                );
            }
        }
    }

    void SpawnCoins()
    {
        foreach (Transform point in coinPoints)
        {
            if (Random.value > 0.3f)
            {
                int index = Random.Range(0, coinPrefabs.Length);
                Instantiate(
                    coinPrefabs[index],
                    point.position,
                    coinPrefabs[index].transform.rotation
                );
            }
        }
    }
}