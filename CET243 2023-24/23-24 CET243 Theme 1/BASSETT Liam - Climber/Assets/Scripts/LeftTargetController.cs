using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class LeftTargetController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 targetPos;
    
   private void Awake()
    {
        
        playerInput = GetComponent<PlayerInput>();
        CustomControls playerInputActions = new CustomControls();
        playerInputActions.Enable();
        playerInputActions.Player.ArmL.performed += ArmL_performed;
        playerInputActions.Player.ArmL.canceled += ArmL_canceled;
    }
    private void Update()
    {
        this.transform.localRotation = Quaternion.Euler(0, 0, 0);
       
    }

    private void ArmL_canceled(InputAction.CallbackContext obj)
    {
        targetPos = new Vector2(0, 0);
        this.transform.localPosition = targetPos;
    }

    private void ArmL_performed(InputAction.CallbackContext context)
    {
        targetPos = context.ReadValue<Vector2>();
        this.transform.localPosition = targetPos;
    }

    
}
