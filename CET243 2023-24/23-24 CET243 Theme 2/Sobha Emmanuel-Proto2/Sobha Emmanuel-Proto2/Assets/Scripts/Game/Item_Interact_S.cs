using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Item_Interact_S : MonoBehaviour
{
    public bool interact_yes;

    private void Start()
    {

        interact_yes = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact_yes = true;
        }
  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           // interact_yes = false;
        }
    }
}
