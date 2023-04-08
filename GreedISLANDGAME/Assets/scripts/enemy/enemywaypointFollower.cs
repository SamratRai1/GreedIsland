using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemywaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 1f;
    private int flipper;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            if(transform.position.x>playerTransform.position.x)
            {
                transform.localScale = new Vector3(4, 4, 4);
                transform.position += Vector3.left*speed*Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-4, 4, 4);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position)<chaseDistance) {
                isChasing = true;
            }
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
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
}
