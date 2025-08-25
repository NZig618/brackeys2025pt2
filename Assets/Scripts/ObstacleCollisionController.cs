using UnityEngine;

public class ObstacleCollisionController : MonoBehaviour
{
    public int damage = 20;
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        var bulletController = collision.gameObject.GetComponent<BulletController>();
        if (bulletController != null)
        {
            TakeDamage(bulletController.damage);
            bulletController.Explode();
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        // Add death effects here (e.g., particle effects, sound)
        Destroy(gameObject);
    }
}
