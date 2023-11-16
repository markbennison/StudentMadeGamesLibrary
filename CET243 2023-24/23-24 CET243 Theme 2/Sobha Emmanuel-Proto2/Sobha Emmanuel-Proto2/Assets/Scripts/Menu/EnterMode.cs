using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMode : MonoBehaviour
{
  
    [SerializeField] private TMP_InputField Player1_Name;
    [SerializeField] private TMP_InputField Player2_Name;

    private string PlayerName1;
    private string PlayerName2;

    private bool Player1Ready;
    private bool Player2Ready;

 
    public void Player1()
    {
        PlayerName1 = Player1_Name.text;
        PlayerPrefs.SetString("Player1_Name", PlayerName1);
        PlayerPrefs.Save();
    }

    public void Player2()
    {
        PlayerName2 = Player2_Name.text;
        PlayerPrefs.SetString("Player2_Name", PlayerName2);
        PlayerPrefs.Save();
    }

    public void Player1_Char(int ID)
    {
        PlayerPrefs.SetInt("Player1_char", ID);
        PlayerPrefs.Save();
    }

    public void Player2_Char(int ID)
    {
        PlayerPrefs.SetInt("Player2_char", ID);
        PlayerPrefs.Save();
    }

    public void Finish1()
    {
        Player1Ready = true;
    }

    public void Finish2()
    {
        Player2Ready = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(PlayerName1 == null)
        {
            PlayerName1 = "Player1";
            PlayerPrefs.SetString("Player1_Name", PlayerName1);
            PlayerPrefs.Save();
        }

        if (PlayerName2 == null)
        {
            PlayerName2 = "Player2";
            PlayerPrefs.SetString("Player2_Name", PlayerName2);
            PlayerPrefs.Save();
        }

        if(Player1Ready && Player2Ready)
        {
            SceneManager.LoadScene(1);
        }
        

    }
}
