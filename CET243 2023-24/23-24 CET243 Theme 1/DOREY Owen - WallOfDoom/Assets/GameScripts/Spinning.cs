using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 0f, 75f * Time.deltaTime, Space.Self);
    }
}
