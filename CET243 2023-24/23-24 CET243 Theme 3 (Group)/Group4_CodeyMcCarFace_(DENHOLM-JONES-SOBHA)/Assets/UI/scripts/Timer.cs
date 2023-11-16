using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 2;
    public bool timerIsRunning = false;
    public Text timeText;
    public Text EndTime;
    public float totalTime = 0;
    private float timeFactor = 0;
    public GameObject EndPage;
    public GameObject PlayPage;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = false;
        EndPage.SetActive(false);
    }
    void Update()
    {
        if (timerIsRunning)
        {
            totalTime += Time.deltaTime;
            DisplayTime(totalTime);
        }
    }
    public void End()
    {
        TimerEnd();
        EndPage.SetActive(true);
        PlayPage.SetActive(true);
    }
    void TimerStart()
    {
        timerIsRunning = true;
    }
    void TimerEnd()
    {
        timerIsRunning = false;
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void TotalTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        EndTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
