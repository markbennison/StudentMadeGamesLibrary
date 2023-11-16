using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float movementspeed = -3;
    public float life = 4;

    private void Awake()
    {
        Destroy(gameObject, life);



    }
    private void Update()
    {
        transform.position += new Vector3(0, movementspeed * Time.deltaTime, 0);

    }
}
