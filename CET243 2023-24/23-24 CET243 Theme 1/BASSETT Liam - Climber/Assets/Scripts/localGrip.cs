using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class localGrip : MonoBehaviour
{
    private PlayerInput playerInput;
    private bool leftGrip = false;
    private bool rightGrip = false;
    private Rigidbody2D rigid;
    private Vector3 pos = new Vector3();

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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

    private void HoldL_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        leftGrip = true;
    }

    private void HoldR_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rightGrip = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D()
    {
        pos = this.transform.position;
        Debug.Log("enter");
        
    }

    void OnTriggerStay2D()
    {
        Debug.Log("stay");
        if(this.tag == "left" && leftGrip == true)
        {
            this.rigid.isKinematic = true;
            this.rigid.constraints = RigidbodyConstraints2D.FreezeAll;

            Debug.Log("Lock");
        }
        else if(this.tag == "right" && rightGrip == true)
        {
            this.rigid.isKinematic = true;
            this.rigid.constraints = RigidbodyConstraints2D.FreezeAll;


            Debug.Log("Lock");
        }
        else
        {
            this.rigid.isKinematic =false;
            this.rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }
}
