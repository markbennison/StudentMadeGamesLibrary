using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Button2 : MonoBehaviour
{
    public GameObject cube;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player 2")
        Destroy(cube);
    }

}