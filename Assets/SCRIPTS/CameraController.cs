using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform ball;        // The ball object the camera should follow
        public float smoothSpeed = 0.125f;  // Smooth follow speed
        public Vector3 offset;        // The offset of the camera relative to the ball

        private void Start()
        {
            // Initialize the camera offset if not set in the inspector
            if (offset == Vector3.zero)
            {
                offset = new Vector3(0, 5, -10);  // Set default camera position
            }
        }

        void LateUpdate()
        {
            // Smoothly follow the ball’s position
            Vector3 desiredPosition = ball.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the camera's position
            transform.position = smoothedPosition;

            // Rotate the camera to always look at the ball
            transform.LookAt(ball);
        }
    }

    //serialize field for the Camera Controller to access from the editor

    [SerializeField] private GameObject player;

    //private field for the Camera Controller
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}

