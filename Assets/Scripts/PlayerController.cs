using UnityEngine;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine.Assertions.Comparers;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private InputActionReference movement, pointerPosition, attack;
    [Header("Shooting Settings")]
    [SerializeField] private float gunHeat;
    [SerializeField] private float cooldown = 0.25f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce = 20f;
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;
    [Header("Invincibility Settings")]
    [SerializeField] private float invincibilityDuration = 1f;
    private float invincibilityTimer = 0f;
    private bool isInvincible = false;
    private Color originalColor;
    private Color flashColor = new Color(1f, 0f, 0f, 0.5f);
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    // Update is called once per frame
    void Update()
    {
        moveDirection = movement.action.ReadValue<Vector2>().normalized;
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        OrientMouse();

        if (gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        }

        if (attack.action.ReadValue<float>() == 1 && gunHeat <= 0)
        {
            gunHeat = cooldown;
            Fire();
        }
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
                spriteRenderer.color = originalColor;
            }
        }
    }

    void OrientMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(pointerPosition.action.ReadValue<Vector2>());
        Vector2 orientation = mousePos - rb.position;
        rb.rotation = Mathf.Atan2(orientation.y, orientation.x) * Mathf.Rad2Deg - 90f;
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var obstacleController = collision.gameObject.GetComponent<ObstacleCollisionController>();
        if (obstacleController != null)
        {
            TakeDamage(obstacleController.damage);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
        // Flash effect to indicate damage
        spriteRenderer.color = flashColor;
        
    }
    
    void Die()
    {
        // Handle player death (e.g., reload scene, show game over screen)
        Debug.Log("Player Died!");
        //Destroy(gameObject);
    }
}
