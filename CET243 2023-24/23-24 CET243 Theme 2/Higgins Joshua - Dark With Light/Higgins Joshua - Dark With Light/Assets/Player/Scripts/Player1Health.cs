using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Health : MonoBehaviour
{

    [SerializeField] float maxHitPoints = 100f;
    float hitPoints;
    private bool dead = false;

    private float damageTimer = 1.2f;
    private float timer = 0f;

    NewPlayer1Movement newPlayer1Movement;

    public bool IsDead
    {
        get
        {
            return dead;
        }
        set
        {
            dead = value;
            newPlayer1Movement.isDead = dead;
        }
    }

    public float CurrentHealth
    {
        get
        {
            return hitPoints;
        }
    }

    void Start()
    {
        hitPoints = maxHitPoints;

        newPlayer1Movement = GetComponent<NewPlayer1Movement>();
    }

    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= damageTimer)
        {
            TakeDamage(20);
            timer = 0f; 
        }
    }

    public void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;

        Debug.Log("OUCH: " + hitPoints.ToString());

        if (hitPoints <= 0)
        {
            OnDeath();
        }
    }


    public void Touch(float rawHeal)
    {
        hitPoints += rawHeal;

        Debug.Log("HEALING! " + hitPoints.ToString());
    }

    float NormalisedHitPoint()
    {
        return hitPoints / maxHitPoints;
    }

    void TakeDamage(float damage)
    {
        hitPoints -= damage;

        Debug.Log("OUCH: " + hitPoints.ToString());

        if (hitPoints <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        Debug.Log("GAME OVER - player 1");
        GetComponent<NewPlayer1Movement>().enabled = false;
        IsDead = true;

        SceneManager.LoadScene(0);
    }



}