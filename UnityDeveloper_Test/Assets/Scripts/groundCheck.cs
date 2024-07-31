using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public bool isGrounded = false;
    public float groundCheckDistance = 0.1f; 
    public LayerMask groundLayer;

    void Update()
    {
        CheckIfGrounded();
    }

    void CheckIfGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
