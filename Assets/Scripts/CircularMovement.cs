using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;        // Movement speed
    [SerializeField] private float rotationSpeed = 90f; // Degrees per second

    private Vector2 velocity;

    void Start()
    {
        // Start moving to the right
        velocity = transform.right * speed;
    }

    void Update()
    {
        // Rotate velocity vector over time
        float angle = rotationSpeed * Mathf.Deg2Rad * Time.deltaTime;
        float cos = Mathf.Cos(angle);
        float sin = Mathf.Sin(angle);

        velocity = new Vector2(
            velocity.x * cos - velocity.y * sin,
            velocity.x * sin + velocity.y * cos
        );

        // Move using velocity
        transform.position += (Vector3)(velocity * Time.deltaTime);

        // Face direction of travel
        float angleDeg = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleDeg);
    }
}
