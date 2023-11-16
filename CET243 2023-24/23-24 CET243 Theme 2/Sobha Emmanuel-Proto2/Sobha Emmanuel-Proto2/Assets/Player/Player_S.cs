using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_S : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 PlayerMovement;
    [SerializeField] private int PlayerIndex = 0;

    public Lvl1_Door_S UseDoor;
    public float MoveSpeed;
    public GameObject TaskPanel;
    public GameObject RangeCheckObj;
    public bool canInteract;
    public GameObject Trigger;
  
    private int CurrentScene;
    public bool isHidden;
    public bool CanActivate;
    public bool CanUse;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CanActivate = true;
        
    }

    public int GetPlayerIndex()
    {
        return PlayerIndex;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + PlayerMovement * MoveSpeed * Time.deltaTime);
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        PlayerMovement = context.ReadValue<Vector2>();
    }

    public void OnHideTask()
    {
        isHidden = !isHidden;
        if(isHidden)
        {
            TaskPanel.SetActive(false);
        }
        else
        {
            TaskPanel.SetActive(true);
        }
    }

    public void OnInteract()
    {
        bool inRange = RangeCheckObj.GetComponent<Interaction>().interact_yes;
        if(inRange){
            canInteract = true;
            
            UseDoor.DoorStats();
        }
        else { canInteract = false; }

        bool TriggerRange = Trigger.GetComponent<LastBtn_S>().interact_yes;
        if (TriggerRange)
        {
            CanUse = true;
            Trigger.GetComponent<LastBtn_S>().complete();
            UseDoor.Goal2Complete();
        }
        else { CanUse = false; }
        
    }
    

   
}
