using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AIDriverController : MonoBehaviour
{

    [Header("General Parameters")]
    public int maxRPM = 150;
    public Transform customDestination;

    [Header("Car Wheels (Wheel Collider)")]
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider backLeft;
    public WheelCollider backRight;

    [Header("Car Wheels (Transform)")]
    public Transform wheelFL;
    public Transform wheelFR;
    public Transform wheelBL;
    public Transform wheelBR;

    public Transform player;

    private bool allowMovement;
    private float LocalMaxSpeed;
    private float MovementTorque = 1;

    private NavMeshAgent navMeshAgent;
    private NavMeshAgent navMeshAgent2;
    private NavMeshPath path;
    private float baseSpeed;

    void Awake() {
        allowMovement = true;
    }

    void Start() {
        path = new NavMeshPath();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent2 = player.GetComponent<NavMeshAgent>();
        baseSpeed = navMeshAgent.speed;
    }

    void FixedUpdate() {
        UpdateWheels();
        PathProgress();

        navMeshAgent.speed = Mathf.Max(baseSpeed, baseSpeed * ((RemainingDistance(navMeshAgent.path.corners) - RemainingDistance(path.corners)) / 100f));
    }

    public float RemainingDistance(Vector3[] points)
    {
        if (points.Length < 2) return 0;
        float distance = 0;
        for (int i = 0; i < points.Length - 1; i++)
            distance += Vector3.Distance(points[i], points[i + 1]);
        return distance;
    }

    private void PathProgress() {
        //Movement();
        NavMesh.CalculatePath(player.position, customDestination.position, NavMesh.AllAreas, path);
        navMeshAgent.SetDestination(customDestination.position);
    }

    private void ApplyBrakes() {
        frontLeft.brakeTorque = 5000;
        frontRight.brakeTorque = 5000;
        backLeft.brakeTorque = 5000;
        backRight.brakeTorque = 5000;
    }


    private void UpdateWheels() {
        ApplyRotationAndPostion(frontLeft, wheelFL);
        ApplyRotationAndPostion(frontRight, wheelFR);
        ApplyRotationAndPostion(backLeft, wheelBL);
        ApplyRotationAndPostion(backRight, wheelBR);
    }

    private void ApplyRotationAndPostion(WheelCollider targetWheel, Transform wheel) {
        targetWheel.ConfigureVehicleSubsteps(5, 12, 15);

        Vector3 pos;
        Quaternion rot;
        targetWheel.GetWorldPose(out pos, out rot);
        wheel.position = pos;
        wheel.rotation = rot;
    }

    void Movement() {
        if (allowMovement == true) {
            frontLeft.brakeTorque = 0;
            frontRight.brakeTorque = 0;
            backLeft.brakeTorque = 0;
            backRight.brakeTorque = 0;

            int SpeedOfWheels = (int)((frontLeft.rpm + frontRight.rpm + backLeft.rpm + backRight.rpm) / 4);

            if (SpeedOfWheels < LocalMaxSpeed) {
                backRight.motorTorque = 400 * MovementTorque;
                backLeft.motorTorque = 400 * MovementTorque;
                frontRight.motorTorque = 400 * MovementTorque;
                frontLeft.motorTorque = 400 * MovementTorque;
            } else if (SpeedOfWheels < LocalMaxSpeed + (LocalMaxSpeed * 1 / 4)) {
                backRight.motorTorque = 0;
                backLeft.motorTorque = 0;
                frontRight.motorTorque = 0;
                frontLeft.motorTorque = 0;
            } else {
                ApplyBrakes();
            }
        } else {
            ApplyBrakes();
        }
    }
}
