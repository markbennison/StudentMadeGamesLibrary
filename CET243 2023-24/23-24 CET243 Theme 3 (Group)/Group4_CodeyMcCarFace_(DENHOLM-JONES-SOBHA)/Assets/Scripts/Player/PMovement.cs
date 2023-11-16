using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityTutorial.Manager;

public class PMovement : MonoBehaviour
{
    [Header("General Parameters")]
    // Car Specs Force Power and Turn Angles
    public float _motorPower;
    public float TurningAngle;
    public float DownForce = 50;
    public bool isEngineOn;
    public float BrakeForce;
    public bool CanResetPos;

    // Rev And Engine Temp Varible Area ;;
    public float maxRPM = 2000;
    public float minRPM = 0f;
    [Range(0, 6)]
    public int CurrentGearValue;
    [Range(0,6)]
    public static int CurrentGear;
    public float[] GearsRatio;
    public float Current_Speed;
    public float currentRPM = 0f;
    public float NeedleAccelerationForce;
    public float NeedleDecelerationForce;
    
    private float CurrentTorque;
    private bool Next;
    private bool Previous;
    
    private bool IsAirborne;
    private float Acceleration;
    private float Brakes;

    private Rigidbody _rb;
    private InputManager _inputManager;

    [Header("Car Wheels (Wheel Collider)")]
    [SerializeField] private WheelCollider frontWheel_R_Col;
    [SerializeField] private WheelCollider frontWheel_L_Col;
    [SerializeField] private WheelCollider backWheel_R_Col;
    [SerializeField] private WheelCollider backWheel_L_Col;

    [Header("Car Wheels (Transform)")]
    [SerializeField] private Transform frontWheel_R;
    [SerializeField] private Transform frontWheel_L;
    [SerializeField] private Transform backWheel_R;
    [SerializeField] private Transform backWheel_L;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = new Vector3(_rb.centerOfMass.x, -1, _rb.centerOfMass.z);
        _inputManager = GetComponent<InputManager>();
        currentRPM = 0;
        isEngineOn = true;
        PMovement.CurrentGear = CurrentGearValue;

    }

    private void FixedUpdate()
    {
        UpdateWheel(frontWheel_R_Col, frontWheel_R);
        UpdateWheel(frontWheel_L_Col, frontWheel_L);
        UpdateWheel(backWheel_R_Col, backWheel_R);
        UpdateWheel(backWheel_L_Col, backWheel_L);

        if (!isEngineOn)
        {
            backWheel_L_Col.brakeTorque = 5000;
            backWheel_R_Col.brakeTorque = 5000;
            frontWheel_L_Col.brakeTorque = 5000;
            frontWheel_R_Col.brakeTorque = 5000;
        }
        else
        {
            backWheel_L_Col.brakeTorque = 0;
            backWheel_R_Col.brakeTorque = 0;
            frontWheel_L_Col.brakeTorque = 0;
            frontWheel_R_Col.brakeTorque = 0;
        }

        CurrentGearValue = PMovement.CurrentGear;
        isEngineOn = _inputManager.EngineOnOff;

        Steering();
        RevEngine();
        ChangeGear();
        Engine();  
        Brake();
        Airborne();
    }

    private void Update()
    {
        Acceleration = _inputManager.Acceleration;
        if(Acceleration != 1) {
            CurrentTorque = 0;
        }
        Brakes = _inputManager.Brake;
        Current_Speed = _rb.velocity.magnitude;
       
    }

    private void Engine()
    {
        if(isEngineOn)
        {
            if (Brakes != 1 && GearsRatio[CurrentGear] != 1 && Acceleration ==1)
            {

                CurrentTorque = Acceleration * _motorPower * currentRPM * GearsRatio[CurrentGear] * Time.deltaTime;
                backWheel_L_Col.motorTorque = CurrentTorque;
                backWheel_R_Col.motorTorque = CurrentTorque;

                backWheel_L_Col.brakeTorque = 0;
                backWheel_R_Col.brakeTorque = 0;

            }
            if (Acceleration != 1)
            {
                CurrentTorque = 0;
                backWheel_L_Col.motorTorque = CurrentTorque;
                backWheel_R_Col.motorTorque = CurrentTorque;
            }
            else if (Brakes == 1 && Acceleration == 1)
            {
                backWheel_L_Col.brakeTorque = 0;
                backWheel_R_Col.brakeTorque = 0;
            }
        }
    }

    private void Brake()
    {
        if(Brakes != -1)
        {
            backWheel_L_Col.brakeTorque += BrakeForce * Time.deltaTime;
            backWheel_R_Col.brakeTorque += BrakeForce * Time.deltaTime;
            frontWheel_L_Col.brakeTorque += BrakeForce / 5F * Time.deltaTime;
            frontWheel_R_Col.brakeTorque += BrakeForce / 5F * Time.deltaTime;
        }
        else
        {
            backWheel_L_Col.brakeTorque = 0;
            backWheel_R_Col.brakeTorque = 0;
            frontWheel_L_Col.brakeTorque = 0;
            frontWheel_R_Col.brakeTorque = 0;
        }
    }

    private void RevEngine()
    {
        if(isEngineOn)
        {
            //Check if engine status 
            if (Acceleration != 1 && currentRPM <= minRPM)
            {
                currentRPM = minRPM;

            }
            else if (Acceleration != 1 && currentRPM > minRPM)
            {
                currentRPM -= currentRPM * Time.deltaTime;//Decrease the currentRPM to minRPM if Engine is On
            }
            
            //Check if RPM has reached MAX RPM
            if (currentRPM == maxRPM)
            {
                currentRPM = maxRPM;
            }

            //Check if Player is accelerating and if not accelerate if max RPM has been reached
            if (Acceleration == 1 && currentRPM < maxRPM)
            {
                currentRPM += NeedleAccelerationForce * Time.deltaTime;
            }
        }
        else if (!isEngineOn && currentRPM > 0)// Check if Engine is on to Turn Off RPM
        {
            currentRPM -= NeedleDecelerationForce * Time.deltaTime;//Decrease the currentRPM to minRPM if Engine is On
        }


    }

    private void ChangeGear()
    {
       Next = _inputManager.NextGear;
       Previous = _inputManager.BackGear;
       

        if(Next)
        {
            CurrentGear++;
        }
        if (Previous)
        {
            CurrentGear--;
        }
       
    
    }

    private void Steering()
    {
        Vector2 turning = _inputManager.Turn;
        frontWheel_L_Col.steerAngle = TurningAngle * turning.x * Time.deltaTime;
        frontWheel_R_Col.steerAngle = TurningAngle * turning.x * Time.deltaTime;
    }

    private void UpdateWheel(WheelCollider col, Transform tr)
    {
        Vector3 pos = tr.position;
        Quaternion rot = tr.rotation;

        col.GetWorldPose(out pos, out rot);
        tr.SetPositionAndRotation(pos, rot);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Track")) { IsAirborne = false; }
        if (collision.gameObject.CompareTag("Ground")) { ResetPos(); }
        CanResetPos = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Track")) { IsAirborne = true; }

    }

    private void Airborne()
    {
        if (IsAirborne)
        {
            //_rb.drag = 1;
            _rb.AddForce(_rb.velocity.magnitude * DownForce * -transform.up);
            _rb.constraints = RigidbodyConstraints.FreezeRotationY;
        }
        else
        {
            //_rb.drag = 0;
            _rb.AddForce(_rb.velocity.magnitude * DownForce * -transform.up);
            _rb.constraints = RigidbodyConstraints.None;

        }
    }

    private void ResetPos()
    {
        //Debug.Log("Resetting Position");
        CanResetPos = true;
    }

}
