using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public Transform wall;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 0.01f;

    int direction = 1;

    void Update()
    {
        Vector2 target = currentMovementTarget();

        wall.position = Vector2.Lerp(wall.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)wall.position).magnitude;

        if (distance <= 0.1f)
        {
             direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }    
        else
        {
            return endPoint.position;
        }
    }


    private void OnDrawGizmos()
    {
        if(wall!=null && startPoint!=null && endPoint!=null)
        {
            Gizmos.DrawLine(wall.transform.position, startPoint.position);
            Gizmos.DrawLine(wall.transform.position, endPoint.position);
        }
    }

}
