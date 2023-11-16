using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        rb.velocity = velocity;
    }
}