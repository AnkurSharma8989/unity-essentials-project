using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Movement")]
    public float rotationSpeed = 100f;
    public float floatSpeed = 2f;
    public float floatHeight = 0.25f;

    [Header("Effects")]
    public GameObject onCollectEffect;
    public GameObject finalVFX;

    [Header("Sounds")]
    public AudioClip collectSound;
    public AudioClip finalSound;

    private static int collectedCount = 0;
    private static int totalCollectibles;

    private static bool sceneInitialized = false;

    private Vector3 startPos;

    void Start()
    {
        // Store original position
        startPos = transform.position;

        // Reset count only once per scene
        if (!sceneInitialized)
        {
            collectedCount = 0;

            totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;

            sceneInitialized = true;
        }
    }

    void Update()
    {
        // Rotate collectible
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        // Floating animation
        float y = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPos + new Vector3(0, y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play collect sound
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Spawn collect VFX
            Instantiate(onCollectEffect, transform.position, Quaternion.identity);

            // Increase count
            collectedCount++;

            // Final collectible reached
            if (collectedCount >= totalCollectibles)
            {
                // Final VFX
                Instantiate(finalVFX, transform.position, Quaternion.identity);

                // Final sound
                AudioSource.PlayClipAtPoint(finalSound, transform.position);

                // Reset for next scene load
                sceneInitialized = false;
            }

            // Destroy collectible
            Destroy(gameObject);
        }
    }
}