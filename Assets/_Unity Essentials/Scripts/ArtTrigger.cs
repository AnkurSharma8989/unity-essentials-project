using UnityEngine;

public class ArtTrigger : MonoBehaviour
{
    public AudioSource voiceAudio;
    public Light artLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            voiceAudio.Play();
            artLight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            voiceAudio.Stop();
            artLight.enabled = false;
        }
    }
}