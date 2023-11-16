using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_S : MonoBehaviour
{
    public GameObject Menu_panel;
    public GameObject EnterMode_panel;
    public GameObject Guide_Panel;

    private void Start()
    {
        Menu_panel.SetActive(true);
        EnterMode_panel.SetActive(false);
        Guide_Panel.SetActive(false);
    }

    public void EnterMode()
    {
        Menu_panel.SetActive(false);
        EnterMode_panel.SetActive(true);
        Guide_Panel.SetActive(false);
    }

    public void EnterGuide()
    {
        Menu_panel.SetActive(false);
        EnterMode_panel.SetActive(false);
        Guide_Panel.SetActive(true);
    }

    public void BackToMenu()
    {
        Menu_panel.SetActive(true);
        EnterMode_panel.SetActive(false);
        Guide_Panel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

}
