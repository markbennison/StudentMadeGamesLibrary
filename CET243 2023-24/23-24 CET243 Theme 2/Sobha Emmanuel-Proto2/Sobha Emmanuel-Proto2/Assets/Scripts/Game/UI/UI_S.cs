using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_S : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Player1Name;
    [SerializeField] private TextMeshProUGUI Player2Name;

    private string Player1_N;
    private string Player2_N;

    private void Start()
    {
        Player1_N = PlayerPrefs.GetString("Player1_Name");
        Player2_N = PlayerPrefs.GetString("Player2_Name");

        Player1Name.text = Player1_N;
        Player2Name.text = Player2_N;
    }



}
