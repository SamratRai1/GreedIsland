using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcollectibles : MonoBehaviour
{
    [SerializeField] private float healthValue;
    public string names;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            

            collision.GetComponent<health>().AddHealth(healthValue);
            if (names == "collectible")
            {
                gameObject.SetActive(false);
            }
            else
            {
                healthValue= 0;
            }
        }
    }
}
