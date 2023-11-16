using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreTextScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int coinAmount;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        
    }


    void Update()
    {
        text.text = coinAmount.ToString();
    }

    
}
