using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenlayer : MonoBehaviour
{
    public Transform playerTransform;
    private bool check=false;
    private void Update()
    {
        //Debug.Log(3);
        if (Vector2.Distance(transform.position, playerTransform.position) < 6.2f)
        {
            check = true;
        }
        else
        {
            check = false;
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag( "playerarrow"))
        {
            Debug.Log(1);
           if (check==true) { 
                gameObject.SetActive(false);
            }
        }
    }
}
