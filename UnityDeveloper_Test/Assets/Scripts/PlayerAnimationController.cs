using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    private groundCheck gc;

    void Start()
    {
        gc = GetComponent<groundCheck>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveZ = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveZ = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        float speed = Mathf.Clamp01(Mathf.Abs(moveX) + Mathf.Abs(moveZ));
        animator.SetFloat("Speed", speed);

        if (gc.isGrounded && Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
