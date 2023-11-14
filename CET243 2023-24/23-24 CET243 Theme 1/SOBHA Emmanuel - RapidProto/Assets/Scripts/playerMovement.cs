using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    // Player Variables
    private PlayerControls inputActions;
    private Rigidbody2D rb;
    private Collider2D cl;
    public float JumpForce;
    public float MoveSpeed;
    private Vector2 Movement;

    // Jump Variables
    public float groundCheckDistance = 0.1f;
    public Transform groundCheck;
    public LayerMask GroundLayer;
    private bool isGrounded;
    private bool CanJump;

    // Attack Variables
    public GameObject Projectile;
    public Transform AttackPoint;
    public float projectile_Speed = 20f;

    // Health Variable
    public int Health;
    public TextMeshProUGUI HP;
    public GameObject GameOver;
    private int MaxHealth = 200;
    

    private void Start()
    {
        inputActions = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();
        Health = MaxHealth;
        
    }

    private void Update()
    {
        // Perform the groundcheck
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, GroundLayer);

        HP.text = ("HP " +Health.ToString());

        if (isGrounded)
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
        }

        if (Health <= 0)
        {
            GameOver.SetActive(true);
        }
        else
        {
            GameOver.SetActive(false);
        }

    }

    public void TakeDamage(int amount)
    {
        Debug.Log("taking Damg");
        Health -= amount;
        Debug.Log(Health);
       
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * MoveSpeed * Time.deltaTime);
        // fix movement
        if (CanJump == true)
        {
            
        }
    }

    private void OnShoot()
    {
        GameObject CurrentSpell = Instantiate(Projectile, AttackPoint.position, AttackPoint.rotation);
        Rigidbody2D rb = CurrentSpell.GetComponent<Rigidbody2D>();
        CurrentSpell.transform.position = AttackPoint.position;
    }

    private void OnMove(InputValue inputValue)
    {
        Movement = inputValue.Get<Vector2>();
    }
    

}

