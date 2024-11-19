using UnityEngine;

public class Cinemachine : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float roationSpeed = 100f;

    private Rigidbody rb;
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void FixedUpdate()
    {
        //get input for movment
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("vertical");

        //Calculate movement direction
        Vector3 moveDirection = transform.forward * vertical;

        //apply force for movment
        rb.AddForce(moveDirection * moveSpeed);

        //rotate the player based on horizontal input
        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);




    }
}
