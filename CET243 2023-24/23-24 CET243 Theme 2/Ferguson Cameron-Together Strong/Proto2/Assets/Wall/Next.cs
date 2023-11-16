using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    
    

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "P1")
        {
            SceneManager.LoadScene(2);
        }

    }

}

