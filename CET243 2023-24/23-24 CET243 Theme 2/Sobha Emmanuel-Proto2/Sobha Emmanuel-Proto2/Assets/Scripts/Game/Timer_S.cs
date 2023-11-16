using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer_S : MonoBehaviour
{
    public float SetTime = 90;
    private float timeRemaining; // Initial time in seconds
    public GameObject DisplayTimer;
    public Lvl1_Door_S door;
    public bool isRunning = false;

    public GameObject Btn1;
    public GameObject Btn2;
    public GameObject Btn3;

    private void Start()
    {
        timeRemaining = SetTime;
        
    }

    private void Update()
    {
        DisplayTimer.GetComponent<TextMeshProUGUI>().text = timeRemaining.ToString();

        if (door.Goal2Active)
        {
            StartTimer();
        }
        else
        {
            ResetTimer();
        }

        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                // Decrease the timeRemaining by the time passed since the last frame
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                // Timer has reached zero, handle the timer completion
                TimerCompleted();
            }
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
        DisplayTimer.SetActive(false);
    }

    public void ResetTimer()
    {
        // Resets the timer to the starting value
        timeRemaining = SetTime;
    }

    private void TimerCompleted()
    {
        // This is called when the timer reaches zero, you can handle your logic here
        door.Goal2Active = false;
        door.Goal2_Obj.SetActive(false);
        Btn1.GetComponent<Btn_S>().ResetChallenge();
        Btn2.GetComponent<Btn_S>().ResetChallenge();
        Btn3.GetComponent<Btn_S>().ResetChallenge();
        StopTimer();
        door.Goal2Complete();
        DisplayTimer.SetActive(false);
        Debug.Log("Timer Completed!");
    }
}
