using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveToTarget : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D rb;
   

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        Vector2 diff = new Vector2(this.transform.position.x - target.transform.position.x, this.transform.position.y - target.transform.position.y);
        rb.AddForce(diff * 0.5f, ForceMode2D.Impulse);
    }

}
