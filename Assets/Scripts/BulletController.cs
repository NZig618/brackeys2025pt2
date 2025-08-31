using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public int damage = 20;
    public float lifetime = 2f;

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
        Explode();
    }
    
}
