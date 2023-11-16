using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    public Rigidbody2D rb;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 7f;
    private bool isFacingRight = true;

    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (!isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
    }


    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump "+ IsGrounded());
        if (context.performed && IsGrounded())
        {
            Debug.Log("Jump ISGROUNDED");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            Debug.Log("Jump CANCELLED");
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }


    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

}        
    

