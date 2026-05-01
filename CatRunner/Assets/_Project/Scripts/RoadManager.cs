using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private float step;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enter"))
        {
            Vector3 p = other.transform.position;
            p.z += step;
            other.transform.position = p;

            RoadContentSpawner spawner =
                other.GetComponentInParent<RoadContentSpawner>();

            if (spawner != null)
            {
                spawner.GenerateContent();
            }
        }
    }
}