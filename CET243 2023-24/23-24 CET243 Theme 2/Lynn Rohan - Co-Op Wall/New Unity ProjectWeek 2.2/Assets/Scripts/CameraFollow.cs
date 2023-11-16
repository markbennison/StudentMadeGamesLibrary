using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x + -3, 0, -10); 
    }
}