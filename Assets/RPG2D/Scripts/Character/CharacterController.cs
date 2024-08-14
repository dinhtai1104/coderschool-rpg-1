using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour // OOP
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CharacterAnimation characterAnimation;
    [SerializeField] private CharacterAttack characterAttack;

    [SerializeField] private float groundCheckLength;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool isFacingRight = true;
    private Vector2 velocity;
    [SerializeField] private bool isGrounded = false;

    private void Update()
    {
        GroundCheck();
        PlayerMovement();
        PlayerJump();
        PlayerAttack();
    }

    private void PlayerAttack()
    {
        if (isGrounded && velocity.x == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                characterAttack.Attack();
            }
        }
    }

    private void GroundCheck()
    {
        Collider2D rch = Physics2D.OverlapCircle(groundCheck.position, groundCheckLength, groundLayer);
        if (rch != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        characterAnimation.SetBool("isGrounded", isGrounded);
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
            rb.velocity = velocity;

            characterAnimation.SetTrigger("jump");
        }
    }

    private void PlayerMovement()
    {
        float xHorizontal = Input.GetAxisRaw("Horizontal");

        velocity = new Vector2(xHorizontal * speed, rb.velocity.y);
        rb.velocity = velocity;
        characterAnimation.SetFloat("velocity", Mathf.Abs(velocity.x));

        FlipHandler(velocity);
    }

    private void FlipHandler(Vector2 velocity)
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckLength);
    }
}
