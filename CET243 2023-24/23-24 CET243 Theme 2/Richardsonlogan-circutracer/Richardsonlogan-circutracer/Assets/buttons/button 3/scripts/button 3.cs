using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button3 : MonoBehaviour
{
    private void onTriggerEnter2D(Collider2D collision)

    {
        SceneManager.LoadScene(2);
    
    }
}
