using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour
{
    public float riseSpeed = 2f; // Adjust this to control the speed of the rising lava

    private void Update()
    {
        // Move the lava upward in each frame
        transform.Translate(Vector2.up * riseSpeed * Time.deltaTime);
    }
}
