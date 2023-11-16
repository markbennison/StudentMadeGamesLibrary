using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float ballSpeed;

    public GameObject fireBallEffect;

    private Rigidbody2D rb2d;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(ballSpeed * transform.localScale.x, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Instantiate(fireBallEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}

