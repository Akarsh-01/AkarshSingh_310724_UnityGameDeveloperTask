using UnityEngine;

public class RotateEnvironmen : MonoBehaviour
{
    public GameObject groundCheckObject; 
    private groundCheck gc;
    public Transform player; 

    private Vector3 selectedAxis; 
    private float rotationAngle; 

    void Start()
    {
        if (groundCheckObject != null)
        {
            gc = groundCheckObject.GetComponent<groundCheck>();
        }
    }

    void Update()
    {
        if (player != null && gc != null && gc.isGrounded)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            selectedAxis = Vector3.forward;
            rotationAngle = 90f;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            selectedAxis = Vector3.forward;
            rotationAngle = -90f;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            selectedAxis = Vector3.right;
            rotationAngle = 180f;
        }

        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            RotateEnvironment(selectedAxis, rotationAngle);
            selectedAxis = Vector3.zero;
            rotationAngle = 0f;
        }
    }

    void RotateEnvironment(Vector3 axis, float angle)
    {
        Vector3 worldAxis = player.TransformDirection(axis);

        transform.RotateAround(player.position, worldAxis, angle);

        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles = new Vector3(
            Mathf.Round(eulerAngles.x / 90) * 90,
            Mathf.Round(eulerAngles.y / 90) * 90,
            Mathf.Round(eulerAngles.z / 90) * 90
        );

        transform.rotation = Quaternion.Euler(eulerAngles);

    }
}
