using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Key_Script : MonoBehaviour
{
    public Door_Scrip Door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Door.Keycount++;
            Destroy(gameObject);

        }
    }


}
