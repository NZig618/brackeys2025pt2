using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public int damage = 20;
    public float lifetime = 2f;

    void Start()
    {

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
}
