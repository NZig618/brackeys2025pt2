using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private float healthThreshold = 20f; // When health is below this, hide
    private GameObject player;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null) return;
        float health = player.GetComponent<PlayerController>().currentHealth;
        image.enabled = health >= healthThreshold;
    }
}
