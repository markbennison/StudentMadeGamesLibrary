using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public Transform PosA, PosB;
    public int Speed;
    Vector2 targetPos;

    private PlayerHealth playerHealth;

    private void Start()
    {
        targetPos = PosB.position;

        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if(playerHealth != null && !playerHealth.IsDead)
        {
            return;
        }

        if (Vector2.Distance(transform.position, PosA.position) < 0.1f)
        {
            targetPos = PosB.position;
        }

        transform.position = Vector2.MoveTowards(transform.position,targetPos, Speed*Time.deltaTime);
    }
}
