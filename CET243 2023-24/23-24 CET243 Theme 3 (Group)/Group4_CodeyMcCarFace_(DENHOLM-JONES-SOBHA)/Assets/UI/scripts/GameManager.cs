using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // DESIGN PATTERN: SINGLETON
    public static GameManager Instance { get; private set; }
    public static Timer GameTimer { get; private set; }

    public static Timer TimerStart { get; private set; }
    public static Timer TimerEnd { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameTimer = GetComponent<Timer>();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Home");
    }
    public void Quit()
    {
        Application.Quit();
    }



}