using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float deactivate_Timer = 3f;
    public float SpellSpeed;
    public int DamageAmount;

    void Update()
    {
        CheckDestroy();
    }

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -SpellSpeed * Time.deltaTime;
    }

    private void CheckDestroy()
    {
        if (TryGetComponent<Collider2D>(out Collider2D col))
        {
            Destroy(gameObject, 5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerMovement>().TakeDamage(DamageAmount);
            Destroy(gameObject);
        }

    }
}
