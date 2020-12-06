/**
    **PlayerController.cs**

    This file focus on the player's movement
        - Also, functionality of the jumping pads and speed boosters
    
    ----

    *Created by Michael Chang on 11-27-2020*

    *Copyright (c) 2020. All rights reserved*
*/

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 60.0f;
    public Camera cam;
    public float jumpForce = 3.0f;

    private Rigidbody rb;
    private Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    private bool onGround = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");

        Vector3 _move = transform.right * _xMov + transform.forward * _zMov;

        // Apply movement
        rb.MovePosition(rb.position + _move * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            // Add force to jump
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            onGround = false; 
        }

        // Calculate rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxis("Mouse X") * sensitivity;

        // Apply rotation
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3 (0.0f, _yRot, 0.0f)));

        // Calculate camera rotation as a 3D vector (turning around)
        float _xRot = Input.GetAxis("Mouse Y") * sensitivity;

        // Apply rotation for camera
        if (cam != null)
        {
            cam.transform.Rotate(new Vector3 (-_xRot, 0.0f, 0.0f));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;

        switch (collision.gameObject.tag) 
        {
            case "SpeedBoost":
                float _xMov = Input.GetAxis("Horizontal");
                float _zMov = Input.GetAxis("Vertical");
                Vector3 _move = transform.right * _xMov + transform.forward * _zMov;
                rb.AddForce(_move * 900);
                break;   
            case "JumpPad":
                rb.AddForce(Vector3.up * 600);
                break;
            default:
                break;
        }
    }
}
