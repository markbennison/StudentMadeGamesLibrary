using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(collision.gameObject);

       
        if (collision.gameObject.tag.Equals("Player") == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else
        {

        }



    }
}
