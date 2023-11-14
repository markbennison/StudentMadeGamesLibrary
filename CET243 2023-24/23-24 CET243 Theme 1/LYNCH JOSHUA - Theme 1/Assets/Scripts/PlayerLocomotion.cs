using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotion : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f; // Adjust this to control movement speed
    private float jumpForce = 10f; // Adjust this to control jump force
    private bool isGrounded = false;
    private bool canJump = true; // Added variable to track jump state

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Handle jump input from controller (Button South)
        if (canJump && isGrounded && Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Handle forward and backward movement using the D-Pad
        float horizontalInput = Gamepad.current != null ? Gamepad.current.dpad.right.ReadValue() - Gamepad.current.dpad.left.ReadValue() : 0f;

        Vector2 moveDirection = new Vector2(horizontalInput, 0f);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        canJump = false; // Prevent further jumping until grounded again
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has landed on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // Allow jumping again
        }
    }
}
