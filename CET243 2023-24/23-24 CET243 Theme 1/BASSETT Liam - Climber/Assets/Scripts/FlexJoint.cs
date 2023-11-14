using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlexJoint : MonoBehaviour
{
    private HingeJoint2D hinge;
    private PlayerInput playerInput;
    private bool flexLeft = false;
    private bool flexRight = false;
    void Awake()
    {
        hinge = GetComponent<HingeJoint2D>();
        CustomControls playerInputActions = new CustomControls();
        playerInputActions.Enable();
        playerInputActions.Player.FlexR.performed += FlexR_performed;
        playerInputActions.Player.FlexL.performed += FlexL_performed;
        playerInputActions.Player.FlexL.canceled += FlexL_canceled;
        playerInputActions.Player.FlexR.canceled += FlexR_canceled;
    }

    private void FlexR_canceled(InputAction.CallbackContext obj)
    {
        flexRight = false;
    }

    private void FlexL_canceled(InputAction.CallbackContext obj)
    {
        flexLeft = false;
    }

    private void FlexL_performed(InputAction.CallbackContext obj)
    {
        flexLeft = true;
    }

    private void FlexR_performed(InputAction.CallbackContext obj)
    {
        flexRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flexLeft == true && this.tag == "left") 
        {
            hinge.useMotor = true;
        }
        else if (flexRight == true && this.tag == "right")
        {
            hinge.useMotor = true;
        }
        else
        {
            hinge.useMotor = false;
        }
    }
}
