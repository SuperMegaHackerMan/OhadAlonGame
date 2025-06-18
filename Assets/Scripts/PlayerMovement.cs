using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.magnitude > 1)
            movement = movement.normalized;

        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastMoveX", movement.x);
            animator.SetFloat("LastMoveY", movement.y);
        }

        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("IsMoving", movement != Vector2.zero);

        UpdateAnimation();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void UpdateAnimation()
    {
        float dirX = animator.GetBool("IsMoving") ? movement.x : animator.GetFloat("LastMoveX");
        float dirY = animator.GetBool("IsMoving") ? movement.y : animator.GetFloat("LastMoveY");

        string state = GetAnimationState(dirX, dirY, animator.GetBool("IsMoving"));
        Debug.Log(state);
        animator.Play(state);
    }

    string GetAnimationState(float x, float y, bool isMoving)
    {
        string prefix = isMoving ? "Walk_" : "Idle_";
        float threshold = 0.1f;
        Debug.Log("=============");
        Debug.Log("x: " + x);
        Debug.Log("y: " + y);
        // Diagonals
        if (x > threshold && y > threshold) return prefix + "Top_Right";
        if (x < -threshold && y > threshold) return prefix + "Top_Left";
        if (x > threshold && y < -threshold) return prefix + "Down_Right";
        if (x < -threshold && y < -threshold) return prefix + "Down_Left";

        if (x == 0 && y > 0) return prefix + "Up";
        if (x == 0 && y < 0) return prefix + "Down";
        if (x < 0 && y == 0) return prefix + "Left";
        if (x > 0 && y == 0) return prefix + "Right";

        // Default fallback
        return "Idle_Down";
    }
}
