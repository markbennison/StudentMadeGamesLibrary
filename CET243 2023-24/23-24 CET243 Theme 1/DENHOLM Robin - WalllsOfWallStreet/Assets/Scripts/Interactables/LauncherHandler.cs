using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LauncherHandler : MonoBehaviour
{

    public Vector3 endPosition;

    public float duration = 2f;
    public int resolution = 10;
    public float height = 2f;

    void OnDrawGizmosSelected() {
        DrawParabolicArch(transform.position, endPosition);
    }
    void Reset() {
        endPosition = transform.position;
    }

    private void DrawParabolicArch(Vector3 startPoint, Vector3 endPoint) {
        Vector3[] points = new Vector3[resolution + 1];

        for (int i = 0; i <= resolution; i++) {
            float t = i / (float)resolution;
            Vector3 currentPoint = CalculatePointOnParabolicPath(startPoint, endPoint, t);
            if (i > 0) {
                Vector3 previousPoint = CalculatePointOnParabolicPath(startPoint, endPoint, (i - 1) / (float)resolution);
                Debug.DrawLine(previousPoint, currentPoint, Color.yellow);
            }
        }
    }

    private Vector3 CalculatePointOnParabolicPath(Vector3 start, Vector3 end, float t) {
        Vector3 midPoint = (start + end) / 2f;

        Vector3 controlPoint = midPoint + Vector3.up * height;

        float u = 1 - t;
        Vector3 p = u * u * start + 2 * u * t * controlPoint + t * t * end;

        return p;
    }

    public IEnumerator FollowParabolicCurve(GameObject mover) {
        float journeyTime = 0f;

        Rigidbody2D rb = mover.GetComponent<Rigidbody2D>();

        while (journeyTime < duration) {
            float t = journeyTime / duration;
            Vector3 targetPosition = CalculatePointOnParabolicPath(transform.position, endPosition, t);
            mover.transform.position = targetPosition;
            journeyTime += Time.deltaTime;
            yield return null;
        }
        mover.transform.position = endPosition;
        rb.velocity = new Vector3(0,rb.velocity.y,0);
    }
}
