using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_S : MonoBehaviour
{
    GameObject Player1;


    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player");
        if(Player1 != null) 
            SetLocation();
        
    }

    private void SetLocation()
    {
        Player1.transform.position = gameObject.transform.position;
    }


}
