using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCoin : MonoBehaviour
{
    public int CoinAmount;
    public TextMeshProUGUI Display;

    // Update is called once per frame
    void Update()
    {
        Display.text = CoinAmount.ToString();
    }
}
