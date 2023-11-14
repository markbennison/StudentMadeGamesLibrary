using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightTargetContoller : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 targetPos;

    private void Awake()
    {

        playerInput = GetComponent<PlayerInput>();
        CustomControls playerInputActions = new CustomControls();
        playerInputActions.Enable();
        playerInputActions.Player.ArmR.performed += ArmR_performed;
        playerInputActions.Player.ArmR.canceled += ArmR_canceled;
    }
    private void Update()
    {
        this.transform.localRotation = Quaternion.Euler(0, 0, 0);

    }

    private void ArmR_canceled(InputAction.CallbackContext obj)
    {
        targetPos = new Vector2(0, 0);
        this.transform.localPosition = targetPos;
    }

    private void ArmR_performed(InputAction.CallbackContext context)
    {
        targetPos = context.ReadValue<Vector2>();
        this.transform.localPosition = targetPos;
    }


}
