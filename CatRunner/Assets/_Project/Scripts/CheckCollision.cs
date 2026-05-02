using UnityEngine;

public class CheckCollision : MonoBehaviour
{
  
    private void Start()
    {
       
    }
    public bool isDead = false;

    private void Update()
    {
        if (isDead)
        {
            Time.timeScale = 0.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            isDead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            GameManager.Instance.AddCoin(1);
            Destroy(other.gameObject);
        }
    }
}
