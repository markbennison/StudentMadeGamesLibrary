using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public TextMeshProUGUI Player1_goal_UI;
    public TextMeshProUGUI Player1_Instruction;
    public TextMeshProUGUI Player1_Goal_Status;

    public Tasks task1;
    public Tasks task2;

    private bool Interact;
    public bool Goal2Active;
    public Timer_S timer;
    private GameObject ActivateTask;
    public GameObject Timer_UI;
    public GameObject Player;

    public GameObject Keys_Obj;
    public GameObject Goal2_Obj;

    public bool Goal1Met;
    public bool Goal2Met;

    public int KeyCount;
    public int ButtonActive;

    private void Start()
    {
        Player1_goal_UI.text = "Welcome";
        Player1_Goal_Status.text = "Game Progress 0%";
        Player1_Instruction.text = "Go to the Door on the other side of the Maze";

        ActivateTask = Player.GetComponent<Player_S>().TaskPanel;
        Keys_Obj.SetActive(false);
        Goal2_Obj.SetActive(false);
        Goal2Active = false;
        Timer_UI.SetActive(false);
    }

    private void Update()
    {
        if (KeyCount == 2) { Goal1Met = true; }

    }

    public void DoorStats()
    {
        Interact = Player.GetComponent<Player_S>().canInteract;

        if (!Goal1Met && Interact)
        {
            ActivateTask.SetActive(true);
            Keys_Obj.SetActive(true);
            Player.GetComponent<Player_S>().isHidden = false;
            Player1_goal_UI.text = task1.TaskName;
            Player1_Instruction.text = task1.TaskDescription;
            Player1_Goal_Status.text = task1.TaskStatus;
        }
        else if (!Goal2Met && Goal1Met && Interact)
        {
            ActivateTask.SetActive(true);
            Goal2_Obj.SetActive(true);
            Goal2Active = true;
            Timer_UI.SetActive(true);
            Player.GetComponent<Player_S>().isHidden = false;
            Player1_goal_UI.text = task2.TaskName;
            Player1_Instruction.text = task2.TaskDescription;
            Player1_Goal_Status.text = task2.TaskStatus;
        }

    }

    public void Goal2Complete()
    {
        Debug.Log("Goal 2 Complete");
        bool canUse = Player.GetComponent<Player_S>().CanUse;
        if (!Goal2Met && canUse)
        {
            Goal2Met = true;
            Goal2_Obj.SetActive(false);
            timer.StopTimer();
        }
    }
}
