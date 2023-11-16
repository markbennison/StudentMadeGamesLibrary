using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreTextScript.coinAmount += 1;
            Destroy(gameObject);
        }
        
        
    }
}
