using UnityEngine;

public class BallCollisionSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the Audio Source component attached to this ball
        audioSource = GetComponent<AudioSource>();
    }

    // This runs automatically whenever the ball hits another object
    void OnCollisionEnter(Collision collision)
    {
        // Play the assigned sound once
        audioSource.Play();
    }
}
