using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public  CarInput inputActions;
    public event Action<InputActionMap> actionMapChange;

    private void Awake()
    {
        inputActions = new CarInput();
    }

    void Start()
    {
        ToggleActionMap(inputActions.Drive);//.Player
    }

    public void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled)
        {
            return;
        }

        inputActions.Disable();
        actionMapChange?.Invoke(actionMap);
        actionMap.Enable();
    }
}