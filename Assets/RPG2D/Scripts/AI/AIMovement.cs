using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected bool isFacingRight;
    [SerializeField] protected Rigidbody2D rb;


    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void FlipHandler(Vector2 velocity)
    {
        Vector3 localScale = transform.localScale;

        if (isFacingRight) // Dang nhin ve phia ben phai
        {
            if (velocity.x < 0) // ma van toc < 0 => nhan vat can di chyen sang ben trai
            {
                isFacingRight = false;
                localScale.x = -1;
            }
        }
        else
        {
            if (velocity.x > 0)
            {
                isFacingRight = true;
                localScale.x = 1;
            }
        }

        transform.localScale = localScale;
    }
}