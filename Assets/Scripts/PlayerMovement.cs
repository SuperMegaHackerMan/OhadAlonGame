using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Prevent diagonal speed boost
        if (movement.magnitude > 1)
            movement = movement.normalized;

        // Update animator
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("IsMoving", movement != Vector2.zero);

        animationHelper();
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void animationHelper()
    {
        if (movement.x == 0 && movement.y > 0)
        {
            Debug.Log("Moving Up");
            animator.Play("Walk_Up");
        }
        else if (movement.x == 0 && movement.y < 0)
        {
            Debug.Log("Moving Down");
            animator.Play("Walk_Down");
        }
        else if (movement.x < 0 && movement.y == 0)
        {
            Debug.Log("Moving Left");
            animator.Play("Walk_Left");
        }
        else if (movement.x > 0 && movement.y == 0)
        {
            Debug.Log("Moving Right");
            animator.Play("Walk_Right");
        }
        else if (movement.x > 0 && movement.y > 0)
        {
            Debug.Log("Moving Up-Right");
            animator.Play("Top_Right");
        }
        else if (movement.x < 0 && movement.y > 0)
        {
            Debug.Log("Moving Up-Left");
            animator.Play("Top_Left");
        }
        else if (movement.x > 0 && movement.y < 0)
        {
            Debug.Log("Moving Down-Right");
            animator.Play("Down_Right");
        }
        else if (movement.x < 0 && movement.y < 0)
        {
            Debug.Log("Moving Down-Left");
            animator.Play("Down_Left");
        }
        else
        {
            Debug.Log("Idle");
            // animator.Play("Idle");
        }
    }
}
