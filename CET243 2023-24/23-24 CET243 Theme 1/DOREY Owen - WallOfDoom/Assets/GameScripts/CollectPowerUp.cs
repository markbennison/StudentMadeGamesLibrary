using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectPowerUp : MonoBehaviour
{
    public GameObject wall;
    public GameObject player;

    public float timeToRemove = 0.4f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            wall.GetComponent<WallMovement>().wallMoveSpeed -= timeToRemove;
            player.GetComponent<PlayerMovement>().speed -= timeToRemove;
            Destroy(gameObject);
        }
    }
}
