using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour 
{
    public GameObject cube;
    public GameObject cube2;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(cube);
    }

}
