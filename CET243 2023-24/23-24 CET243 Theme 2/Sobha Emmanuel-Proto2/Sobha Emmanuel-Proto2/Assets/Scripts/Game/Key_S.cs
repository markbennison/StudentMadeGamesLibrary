using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_S : MonoBehaviour
{
    public Lvl1_Door_S Door2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Door2.KeyCount ++;
            Destroy(gameObject);
        }
    }
}
