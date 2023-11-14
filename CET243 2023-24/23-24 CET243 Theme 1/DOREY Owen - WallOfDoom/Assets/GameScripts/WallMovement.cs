using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public GameObject player;
    public Transform wall;
    public Transform cam;
    public float wallMoveSpeed = 1f;

    public float speedUpTime = 2f;
    public float speedUpAmount = 0.5f;

    private float offset = 10f;
    void Update()
    {
        Vector3 wallPosition = new Vector3((wall.position.x + 1), wall.position.y, 0);
        wall.position = Vector3.Lerp(wall.position, wallPosition, wallMoveSpeed*Time.deltaTime);

        Vector3 camPosition = new Vector3((wall.position.x + offset), wall.position.y, -10f);
        cam.position = camPosition;
    }

    void Start()
    {
        InvokeRepeating("SpeedUp", speedUpTime, speedUpTime);
    }

    void SpeedUp()
    {
        wallMoveSpeed += speedUpAmount;
        player.GetComponent<PlayerMovement>().speed += speedUpAmount;
    }
}
