using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notice : MonoBehaviour
{
    public GameObject Message;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Player")
        {
            Message.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Message.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
