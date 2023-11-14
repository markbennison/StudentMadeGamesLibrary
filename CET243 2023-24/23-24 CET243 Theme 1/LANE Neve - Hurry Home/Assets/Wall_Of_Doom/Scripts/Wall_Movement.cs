using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall_Movement: MonoBehaviour
{
    [SerializeField] private Transform Destination;
    [SerializeField] float Wall_Move_Speed;

    void Update()
    {
        var Distance_To_Destination = Wall_Move_Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Destination.position, Distance_To_Destination);
    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            GameObject Player = GameObject.Find("Player");
            Player_Movement Player_Movement_Script = Player.GetComponent<Player_Movement>();

            //Debug.Log("Player has entered the Wall");
            Player_Movement_Script.Life -= 1;
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
