using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLocomotion : MonoBehaviour
{
    [SerializeField]
    public Transform WallStop;
    
    
    float WallSpeed = 10f;
    public GameObject target;
    Vector2 targetVector;
    Vector3 moveVector;
    // Update is called once per frame
    void Update()
    {
        targetVector = target.transform.position - transform.position;
        moveVector =targetVector.normalized*WallSpeed*Time.deltaTime;
        transform.Translate(moveVector);
    }

   
}
