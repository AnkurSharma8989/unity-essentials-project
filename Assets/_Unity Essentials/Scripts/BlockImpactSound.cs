using UnityEngine;

public class BlockImpactSound : MonoBehaviour
{
    public AudioSource audioSource;

    // Minimum speed required to play sound
    public float minImpactVelocity = 1.5f;

    void Start()
    {
        // Get the Audio Source component attached to this ball
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check how hard the collision was
        if (collision.relativeVelocity.magnitude > minImpactVelocity)
        {
            audioSource.Play();
        }
    }
}