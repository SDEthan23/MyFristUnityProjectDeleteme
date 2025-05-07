using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;
    private int currentWayPointIndex = 0;

    private void Update()
    {
        if(waypoints.Length > 0)
        {
            Vector2 targetPosition = waypoints[currentWayPointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if(Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Length;
            }
        }   
    }
}
    