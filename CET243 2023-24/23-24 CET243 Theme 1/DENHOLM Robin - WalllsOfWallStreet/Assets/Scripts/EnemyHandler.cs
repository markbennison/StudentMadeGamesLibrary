using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;
    public float speed;
    private float fraction = 0;
    SpriteRenderer spriteRenderer;

    void Reset() {
        startPos = transform.position;
        endPos = transform.position;
    }

    void OnDrawGizmosSelected() {
        Debug.DrawLine(startPos, endPos, Color.magenta);
    }

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (fraction < 1) {
            fraction += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, fraction);
        } else {
            fraction = 0;
            SwapDestination();
        }
    }

    void SwapDestination() {
        Vector3 temp = startPos;
        startPos = endPos;
        endPos = temp;
        spriteRenderer.flipX = (startPos - endPos).x > 0;
    }
}
