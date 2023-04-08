using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenrun : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 20f;
    public bool switchon=true;
    public GameObject switcher;
    private Rigidbody2D rb;
    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionrEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Falldetector")
        {
            Destroy(gameObject);
        }
        switchon = true ;
        Debug.Log(".ad");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        switchon = false;
        Debug.Log(".");
    }
    void Update()
    {
        if (switcher.activeSelf==false & switchon==true)
        {
            transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);
        }
    }
}
