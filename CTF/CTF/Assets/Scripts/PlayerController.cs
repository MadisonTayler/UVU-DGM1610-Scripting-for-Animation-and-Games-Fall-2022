using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed;
    public float jumpForce;
    [Header("Camera")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    // Private variables
    private float rotX;
    private Camera camera;
    private Rigidbody rb;

    void Awake()
    {
        // Get componenets
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraLook();

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed; // Getting input for left and right movement
        float z = Input.GetAxis("Vertical") * moveSpeed; // Getting input for forward and back movement

        // Walk in the direction you're looking/facing
        Vector3 dir = (transform.right * x) + (transform.forward * z);
        dir.y = rb.velocity.y;

        rb.velocity = dir; // Drives movement relative to the camera's look direction
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity; // Look up and down (contrary to what you would think)
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity; // Look left and right
        
        // Restrict rotation on the x-axis between maxLookX to minLookX
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        // Drives camera rotation
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
