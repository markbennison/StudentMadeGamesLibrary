using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionByInput : MonoBehaviour
{
    public float moveSpeed = 10f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime,0f,0f);

        transform.Translate(0f,Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, 0f);
    }
}
