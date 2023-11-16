using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Lvl1_Door_S Door2;
    public GameObject interact_UI;
    public bool interact_yes;

    private void Start()
    {
        interact_UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Door2.DoorStats();
            interact_UI.SetActive(true);
            interact_yes = true;
            Debug.Log("contact");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                interact_UI.SetActive(false);
                interact_yes = false;
                Debug.Log("leaving");
            }
        }
       
    }
}
