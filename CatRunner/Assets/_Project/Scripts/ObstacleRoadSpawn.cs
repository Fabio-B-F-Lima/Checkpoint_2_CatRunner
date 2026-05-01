using UnityEngine;

public class ObstacleRoadSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] obstacles;

    public void GenerateObstacles()
    {
        
        foreach (Transform point in spawnPoints)
        {
            if (point.childCount > 0)
            {
                Destroy(point.GetChild(0).gameObject);
            }

            
            if (Random.value > 0.5f)
            {
                int index = Random.Range(0, obstacles.Length);

                Instantiate(
                    obstacles[index],
                    point.position,
                    Quaternion.identity,
                    point
                );
            }
        }
    }
}