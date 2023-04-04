using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdamager : MonoBehaviour
{
    [SerializeField]private float damage;
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<health>().TakeDamage(damage);
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health health = collision.gameObject.GetComponent<health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
