using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HitManager : MonoBehaviour
{
    public float maxHealth;
    private float health;
    public Slider slider;
    [HideInInspector] public GameObject EnemySpawner;

    private void Start()
    {
        EnemySpawner = GameObject.FindWithTag("EnemySpawner");
        health = maxHealth;
    }
    public void Hit(float dmg)
    {
        Debug.Log(" Took " + dmg + " dmg");
        health -= dmg;
        
        if (health <= 0)
        {
            Death();    
        }
        else
        {
            slider.value = health/maxHealth;
        }

    }
    void Death()
    {
        switch(gameObject.tag)
        {
            case "Player":
            IGMenuController controller = FindAnyObjectByType<IGMenuController>();
            controller.DeathSequence();
            break;
            case "Enemy":
               
            GameObject manager = GameObject.FindGameObjectWithTag("EnemySpawner");
                EnemyManager enemyManager = manager.GetComponent<EnemyManager>();
            enemyManager.SpawnEnemy();
            
                //spawn new enemy to be added
                Destroy(gameObject);
                break ;
        }
    }
}
