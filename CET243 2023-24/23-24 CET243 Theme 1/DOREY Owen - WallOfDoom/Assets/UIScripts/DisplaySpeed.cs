using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySpeed : MonoBehaviour
{
    public GameObject wall;
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        float speed = wall.GetComponent<WallMovement>().wallMoveSpeed;
        text.text = "Speed: " + speed.ToString("F1");
    }
}
