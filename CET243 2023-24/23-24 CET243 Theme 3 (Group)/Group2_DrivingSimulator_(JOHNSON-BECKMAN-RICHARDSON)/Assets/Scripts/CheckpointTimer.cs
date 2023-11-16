using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointTimer : MonoBehaviour
{
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI bestTimeText;

    private float currentTime = 0;
    private float bestTime = 0;
    public int scoreTime;

    private bool startTimer = false;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;
    private int save;
    private void Start()
    {
        PlayerPrefs.DeleteKey("Toptime");
    }
    private void Update()
    {
     
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        currentTimeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);

        if (startTimer == true)
        {
            currentTime = currentTime + Time.deltaTime;          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "StartFinish")
        {
            if (startTimer == false)
            {
                startTimer = true;
                currentTime = 0;
                checkpoint1 = false;
                checkpoint2 = false;
            }

            if (checkpoint1 == true && checkpoint2 == true)
            {
                startTimer = false;

                if (bestTime == 0)
                {
                    bestTime = currentTime;
                    Debug.Log(bestTime);

                    scoreTime = (int)bestTime;
                    SceneManager.LoadScene("LeaderboardTest 1");




                }
                if (currentTime < bestTime)
                {
                    bestTime = currentTime;
                }

                
                int minutes = Mathf.FloorToInt(bestTime / 60);
                int seconds = Mathf.FloorToInt(bestTime % 60);
                bestTimeText.text = "Best Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }

        if (other.gameObject.name == "Checkpoint1")
        {
            checkpoint1 = true;
        }

        if (other.gameObject.name == "Checkpoint2")
        {
            checkpoint2 = true;
        }
    }
}