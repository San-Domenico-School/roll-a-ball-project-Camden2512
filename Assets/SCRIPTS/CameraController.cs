using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;          // The target object the camera will look at
    public float distance = 2f;       // Distance from the target (camera distance)
    public float rotationSpeed = 2f;  // Speed of camera rotation
    public float verticalRotationLimit = 90f; // Max vertical rotation limit

    private float currentHorizontalAngle = 0f;
    private float currentVerticalAngle = 0f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned to CameraController.");
            return;
        }

        // Initialize the camera's position
        UpdateCameraPosition();
    }

    void Update()
    {
        // Get mouse input for rotating the camera
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        // Update horizontal and vertical rotation angles
        currentHorizontalAngle += horizontalInput * rotationSpeed;
        currentVerticalAngle -= verticalInput * rotationSpeed;

        // Clamp vertical rotation to avoid flipping over the target
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, -verticalRotationLimit, verticalRotationLimit);

        // Update camera position and rotation
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        // Calculate the new position based on the current rotation angles
        Quaternion rotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
        Vector3 offset = rotation * Vector3.back * distance;  // Look 7 meters away from the target

        // Set the camera's position
        transform.position = target.position + offset;

        // Make the camera look at the target
        transform.LookAt(target.position);
    }
}