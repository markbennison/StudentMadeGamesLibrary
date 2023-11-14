using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDistance : MonoBehaviour
{
    public GameObject player;
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        float distance = player.transform.position.x + 10f;
        text.text = "Distance: " + distance.ToString("F0");
    }
}
