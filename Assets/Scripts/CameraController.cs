using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [Header("Camera Thresholds")]
    [SerializeField] private float xThreshold = 2f;
    //[SerializeField] private float yThreshold = 2f;
    //[SerializeField] private float followSpeed = 5f;
    [Header("Camera Bounds")]
    [SerializeField] private float minX = -100f;
    [SerializeField] private float maxX = 100f;
    [SerializeField] private float minY = -100f;
    [SerializeField] private float maxY = 100f;
    void Update()
    {
        if (player == null) return;

        Vector3 cameraPos = transform.position;
        Vector3 playerPos = player.position;
        Vector3 offset = playerPos - cameraPos;
        offset.z = 0;

        float xOffset = Mathf.Abs(offset.x);
        float yOffset = Mathf.Abs(offset.y);

        Vector3 targetPos = cameraPos;

        if (xOffset > xThreshold)
            targetPos.x = playerPos.x - Mathf.Sign(offset.x) * xThreshold;

        //if (yOffset > yThreshold)
        //    targetPos.y = playerPos.y - Mathf.Sign(offset.y) * yThreshold;
        targetPos.y = cameraPos.y; // Lock Y-axis movement

        targetPos.z = cameraPos.z;

        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        //transform.position = Vector3.Lerp(cameraPos, targetPos, followSpeed * Time.deltaTime);
        transform.position = targetPos;
    }
}