using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    private Vector3 initalPos;
    float index; 
    private void Awake() {
        initalPos = transform.position;
    }

    void FixedUpdate() {
        index += Time.deltaTime;
        transform.position = new Vector3(initalPos.x, initalPos.y + (Mathf.Sin(index)/2), initalPos.z);
    }
}
