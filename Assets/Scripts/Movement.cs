using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] GameObject Main_Camera, Camera;
    float currentSpeed;
    Rigidbody rb;
    Vector3 direction;
    bool isGrounded = true;
    public enum Cameras
    {
        Main_Camera,
        Camera
    }
    Cameras cameras = Cameras.Main_Camera;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;

        Main_Camera.SetActive(true);
        Camera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChooseCamera(Cameras.Main_Camera);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChooseCamera(Cameras.Camera);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = shiftSpeed;
        }
        else
        {
            currentSpeed = movementSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    public void ChooseCamera(Cameras cameraChoice)
    {
        if (cameraChoice == Cameras.Main_Camera)
        {
            Main_Camera.SetActive(true);
            Camera.SetActive(false);
        }
        else if (cameraChoice == Cameras.Camera)
        {
            Main_Camera.SetActive(false);
            Camera.SetActive(true);
        }
    }
}
