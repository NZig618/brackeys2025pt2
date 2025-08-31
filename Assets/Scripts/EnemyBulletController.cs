using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour
{
    public float lifetime = 1f;

    void Start()
    {
        // Start a coroutine that waits then destroys
        StartCoroutine(LifetimeRoutine());
    }

    private IEnumerator LifetimeRoutine()
    {
        yield return new WaitForSeconds(lifetime);
        Explode();
    }

    public void Explode()
    {
        // Add explosion effects here (e.g., particle effects, sound)
        Destroy(gameObject);
    }

    //If object goes off screen, destroy without animating
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Terrain"))
        {
            Explode();
        }
    }
}
