using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemywaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    private int flipper;
    // Update is called once per frame
    void Update() 
    {
     if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex>=waypoints.Length)
            {
                currentWaypointIndex = 0;
                
            }
            if (flipper > 0)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            flipper += 1;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}