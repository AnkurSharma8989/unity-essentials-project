using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    public float sprintSpeed = 20f;
    public float verticalSpeed = 5f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 2f;

    [Header("Zoom")]
    public float zoomSpeed = 10f;
    public float minFOV = 20f;
    public float maxFOV = 80f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MoveCamera();
        RotateCamera();
        ZoomCamera();

        // Press ESC to unlock mouse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void MoveCamera()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Ignore camera up/down tilt for movement
        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = transform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 move = right * moveX + forward * moveZ;

        // Up movement
        if (Input.GetKey(KeyCode.E))
        {
            move += Vector3.up * verticalSpeed;
        }

        // Down movement
        if (Input.GetKey(KeyCode.Q))
        {
            move += Vector3.down * verticalSpeed;
        }

        transform.position += move * speed * Time.deltaTime;
    }

    void RotateCamera()
    {
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }

    void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        cam.fieldOfView -= scroll * zoomSpeed;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
    }
}