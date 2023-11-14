using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    // health
    public int Health;
    private int MaxHealth = 100;

    // attack
    public GameObject Projectile;
    public Transform AttackPoint;
    public Transform PlayerObj;
    public float DistanceRange;
    public float AttackReset;
    public float AttackTime;
    public LayerMask Player;
    private bool isAttacking;

    // Update Stats
    public Door_Scrip Door;
    public bool IsBoss;
   
    void Start()
    {
        if(IsBoss)
        {
            Health = 250;
        }
        else
        {
            Health = MaxHealth;
        }
        
    }

    public void TakeDamage(int Amount)
    {
        Health -= Amount;
    }

    private void Shoot()
    {
        if (isAttacking)
        {
            AttackReset = 0f;
            GameObject CurrentSpell = Instantiate(Projectile, AttackPoint.position, AttackPoint.rotation);
            Rigidbody2D rb = CurrentSpell.GetComponent<Rigidbody2D>();
            CurrentSpell.transform.position = AttackPoint.position;
        }  
    }

    private void IsReadyToAttack()
    {
        if (AttackReset < AttackTime)
        {
            AttackReset += Time.deltaTime;
            isAttacking = false;
        }
        else
        {
            isAttacking = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        isAttacking = Physics2D.Raycast(AttackPoint.position, Vector2.left, DistanceRange, Player);
        IsReadyToAttack();
        if (isAttacking == true)
        {
            Shoot();
        }


        if(!IsBoss && Health <= 0)
        {
            Debug.Log("Enemy Killed");
            Door.Enemy_Killed++;
            Destroy(gameObject);
        }

        if(IsBoss && Health <= 0)
        {
            Door.BossKilled = true;
            Destroy(gameObject);
        }
    }

   
}
