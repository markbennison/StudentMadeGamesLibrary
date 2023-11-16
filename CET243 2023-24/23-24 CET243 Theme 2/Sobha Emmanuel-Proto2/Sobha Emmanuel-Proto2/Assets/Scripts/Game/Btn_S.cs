using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_S : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    public GameObject Trap;
    public bool CanUse;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.color = Color.red;        
    }

    public void ResetChallenge()
    {
        Trap.SetActive(true);
        spriteRend.color = Color.red;
        GetComponentInChildren<Item_Interact_S>().interact_yes = false;
    }

    // Update is called once per frame
    void Update()
    {
        CanUse = GetComponentInChildren<Item_Interact_S>().interact_yes;

        if(CanUse)
        {
            Trap.SetActive(false);
            spriteRend.color = Color.green;
        }
    }
}
