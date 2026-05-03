using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float speedIncrease;
    public bool isDead = false;

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
        else if (other.gameObject.tag == "Enter" && player.speed < player.maxSpeed)
        {
            player.speed += speedIncrease;
            player.stepSpeed += 0.05f;
        }

    }

}