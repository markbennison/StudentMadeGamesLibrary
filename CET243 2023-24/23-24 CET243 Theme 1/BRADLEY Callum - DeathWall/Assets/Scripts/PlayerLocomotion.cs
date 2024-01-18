using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class PlayerLocomotion : MonoBehaviour
{
    public float moveSpeed = 10f;

    private void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector2.up * moveSpeed* Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}
