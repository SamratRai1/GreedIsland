using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 1f;
    public bool bot;
    private int flipper;
    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {

            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;

            }
           // if (flipper > 0)
            //{
                Vector3 theScale = transform.localScale;
            //theScale.x *= -1;
            //transform.localScale = theScale;
            //}
            
        }
        if (bot == true)
        {
            if (transform.position.x > waypoints[currentWaypointIndex].transform.position.x)
            {

                transform.localScale = new Vector3(4, 4, 4);
            }
            if (transform.position.x < waypoints[currentWaypointIndex].transform.position.x)
            {
                transform.localScale = new Vector3(-4, 4, 4);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

    }
}
