using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("How many real-time seconds a full day takes")]
    public float dayDurationInSeconds = 120f;

    [Tooltip("Axis to rotate around (usually X for sun movement)")]
    public Vector3 rotationAxis = Vector3.right;

    private float rotationSpeed;

    void Start()
    {
        // 360 degrees per full day
        rotationSpeed = 360f / dayDurationInSeconds;
    }

    void Update()
    {
        // Rotate the light over time
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}