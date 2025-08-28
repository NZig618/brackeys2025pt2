using UnityEngine;

public class ChaseMovement : MonoBehaviour
{
    [Header("Chase Parameters")]
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private float chaseSpeed = 3f;
    private GameObject player;
    private bool isChasing = false;
    [Header("Gizmo Settings")]
    [SerializeField] private Color gizmoIdleColor = Color.green;
    [SerializeField] private Color gizmoChaseColor = Color.red;
    [SerializeField] private bool showGizmos = true;
    [SerializeField] private LayerMask playerLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if player is within detection radius
        Collider2D detectionArea = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        //if player is detected, start chasing
        isChasing = detectionArea != null;
        //Move towards player if chasing
        if (isChasing && player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.position += (Vector3)(direction * chaseSpeed * Time.fixedDeltaTime);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), 0.1f);
        }
    }
    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Gizmos.color = isChasing ? gizmoChaseColor : gizmoIdleColor;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
