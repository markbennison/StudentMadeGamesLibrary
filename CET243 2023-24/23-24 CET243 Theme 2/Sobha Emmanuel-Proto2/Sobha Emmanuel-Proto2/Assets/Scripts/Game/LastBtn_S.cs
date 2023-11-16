using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBtn_S : MonoBehaviour
{
    public Lvl1_Door_S Door2;
    public GameObject interact_UI;
    public SpriteRenderer parent;
    public bool interact_yes;

    private void Start()
    {
        interact_UI.SetActive(false);
        parent.color = Color.red;
    }

    public void complete()
    {
        parent.color = Color.green;
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact_UI.SetActive(true);
            interact_yes = true;
            Debug.Log("contact");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact_UI.SetActive(false);
            interact_yes = false;
            Debug.Log("leaving");
        }
    }

}
