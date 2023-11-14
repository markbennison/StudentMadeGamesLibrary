using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door_Scrip : MonoBehaviour
{
    // Get Goal in UI display
    public TextMeshProUGUI Goal1;
    public TextMeshProUGUI Goal2;
    public TextMeshProUGUI Goal3;

    // set Goal status in display
    public TextMeshProUGUI GoalStatus1;
    public TextMeshProUGUI GoalStatus2;
    public TextMeshProUGUI GoalStatus3;

    // Set in UI display
    public string GoalName1;
    public string GoalName2;
    public string GoalName3;

    // Set Goal status in UI display

    private string GoalStat1;
    private string GoalStat2;
    private string GoalStat3;

    public bool Completed_Goal1;
    public bool Completed_Goal2;
    public bool Completed_Goal3;

    public int Keycount;
    public int Enemy_Killed;
    public bool BossKilled;

    private void Update()
    {
        Goal1.text = GoalName1;
        Goal2.text = GoalName2;
        Goal3.text = GoalName3;

        GoalStatus1.text = GoalStat1;
        GoalStatus2.text = GoalStat2;
        GoalStatus3.text = GoalStat3;

        CheckStats();
    }

    private void Start()
    {
        Keycount = 0;
        Enemy_Killed = 0;
        BossKilled = false;
    }

    private void CheckStats()
    {
        // Check Goal 1 status
        if(Completed_Goal1 == true)
        {
            GoalStat1 = "Completed";
        }
        else
        {
            GoalStat1 = "InProgress";
        }

        // Check Goal 2 status
        if (Completed_Goal2 == true)
        {
            GoalStat2 = "Completed";
        }
        else
        {
            GoalStat2 = "InProgress";
        }

        // Check Goal 3 status
        if (Completed_Goal3 == true)
        {
            GoalStat3 = "Completed";
        }
        else
        {
            GoalStat3 = "InProgress";
        }
         
        if(Keycount == 2)
        {
            Completed_Goal2 = true;
        }
        else
        {
            Completed_Goal2 = false;
        }

        if(Enemy_Killed == 3)
        {
            Completed_Goal1 = true;
        }
        else
        {
            Completed_Goal1 = false;
        }
        if(BossKilled == true)
        {
            Completed_Goal3 = true;
        }
        else
        {
            Completed_Goal3 = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Completed_Goal1 && Completed_Goal2 && Completed_Goal3 == true)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Level Complete");
                SceneManager.LoadScene("NextLvl");
            }
        }
       
    }
}
