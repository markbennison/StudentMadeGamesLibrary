using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    float HitPoints = 10f;

    public void Hit(float rawDamage)
    {
        HitPoints -= rawDamage;

        if (HitPoints < 0)
        {
            Debug.Log("Game Over: You Died");
        }
    }
}
