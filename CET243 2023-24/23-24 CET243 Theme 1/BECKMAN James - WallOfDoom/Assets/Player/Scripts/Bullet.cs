using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{

    public float life = 3;

    private void Awake()
    {
        Destroy(gameObject, life);
        
       
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {
            Destroy(collision.gameObject);

        }
        else
        {

        }

        
            Destroy(gameObject);
        
          
    }
}
