using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentwaypointIndex = 0;
    [SerializeField] private float speed = 2f;
   private void Update()
    {
        if(Vector2.Distance(waypoints[currentwaypointIndex].transform.position,transform.position)<0.1f)
		{
            currentwaypointIndex++;
            if(currentwaypointIndex>=waypoints.Length) //after move to wave length initliaze with 0 and move in another direction
			{
                currentwaypointIndex = 0;
			}

        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypointIndex].transform.position, Time.deltaTime * speed);

    }
}
