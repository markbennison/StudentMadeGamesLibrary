using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grip : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject handL;
    public GameObject handR;
    private Rigidbody2D rigidL;
    private Rigidbody2D rigidR;
    private CircleCollider2D colL;
    private CircleCollider2D colR;
    private CircleCollider2D colH;
    private bool leftGrip = false;
    private bool rightGrip = false;
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidL = handL.GetComponent<Rigidbody2D>();
        rigidR = handR.GetComponent<Rigidbody2D>();
        colL = handL.GetComponent<CircleCollider2D>();
        colR = handR.GetComponent<CircleCollider2D>();
        CustomControls playerInputActions = new CustomControls();
        playerInputActions.Enable();
        playerInputActions.Player.HoldR.performed += HoldR_performed;
        playerInputActions.Player.HoldL.performed += HoldL_performed;
        playerInputActions.Player.HoldR.canceled += HoldR_canceled;
        playerInputActions.Player.HoldL.canceled += HoldL_canceled;
    }
    private void HoldL_canceled(InputAction.CallbackContext obj)
    {
        leftGrip = false;
    }

    private void HoldR_canceled(InputAction.CallbackContext obj)
    {
        rightGrip = false;
    }

    private void HoldL_performed(InputAction.CallbackContext obj)
    {
        leftGrip = true;
        Debug.Log(leftGrip);
    }

    private void HoldR_performed(InputAction.CallbackContext obj)
    {
        rightGrip = true;
        Debug.Log(rightGrip);
    }

    void FixedUpdate()
    {

    }

    void OnTriggerStay(UnityEngine.Collider other)
    {
        Debug.Log("Collion");
        if (leftGrip==true && other.tag == "left") {
            rigidL.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        
    }
}
