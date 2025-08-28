using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Shooting Parameters")]
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private float fireForce = 20f;
    [SerializeField] private float cooldown = 0.25f;
    private float gunHeat;
    [Header("References")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask playerLayer;
    private GameObject player;
    [Header("Gizmo Settings")]
    [SerializeField] private Color gizmoIdleColor = Color.yellow;
    [SerializeField] private bool showGizmos = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //check if player is within detection radius
        Collider2D detectionArea = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        //if player is detected, start chasing
        if (detectionArea != null && detectionArea.gameObject == player && gunHeat <= 0)
        {
            gunHeat = cooldown;
            Fire();
        }
        else
        {
            gunHeat -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Gizmos.color = gizmoIdleColor;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    void Fire()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized; //Get direction to player
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); //Instantiate bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //Get bullet Rigidbody2D
        rb.AddForce(direction * fireForce, ForceMode2D.Impulse); //Shoot bullet towards player
    }
}
