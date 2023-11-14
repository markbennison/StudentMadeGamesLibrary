using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovement : MonoBehaviour
{
    [SerializeField] GameObject[] Waypoints;
    [SerializeField] float speed = 1f;
    public playerMovement playerMovement;

    int currentWaypointIndex = 0;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= Waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = 0;
            playerMovement.TakeDamage(200);
        }
    }
}
