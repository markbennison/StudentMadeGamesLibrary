using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamage : MonoBehaviour
{
    float rawDamage = 25f;
    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.tag == "Player")
        {
            GetComponent<HealthManager>().Hit(rawDamage);
        }
    }
}
