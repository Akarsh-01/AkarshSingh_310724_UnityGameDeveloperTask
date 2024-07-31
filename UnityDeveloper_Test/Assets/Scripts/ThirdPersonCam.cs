using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Transform playerCamera;

    public float rotationSpeed = 10f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
      
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

      
        RotatePlayer();
    }

    private void RotatePlayer()
    {
       
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

      
        Vector3 forward = playerCamera.forward;
        Vector3 right = playerCamera.right;

       
        forward.Normalize();
        right.Normalize();

     
        Vector3 inputDirection = (forward * verticalInput + right * horizontalInput).normalized;

       
        inputDirection.y = 0;

      
        if (inputDirection != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDirection, Time.deltaTime * rotationSpeed);
        }
    }
}
