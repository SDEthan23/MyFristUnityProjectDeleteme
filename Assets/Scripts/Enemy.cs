using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool destroyOnCollision = false;
    public int damageToPlayer = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamageToPlayer(collision);
        }
    }

    private void DealDamageToPlayer(Collider2D player)
    {
        PlayerHealth playerHealth = player.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageToPlayer);
        }

        if (destroyOnCollision)
        {
            Destroy(gameObject);
        }
    }
}
