using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemychase : MonoBehaviour
{
    public float chaseDistance;
    public Transform playerTransform;
    [SerializeField] private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ground" & collision.gameObject.tag!="Player")
        {
            StartCoroutine(Destroyer());
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            GetComponent<waypointFollower>().enabled = false;
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(4, 4, 4);
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-4, 4, 4);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            GetComponent<waypointFollower>().enabled = true;
        }
    }
    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);

    }


}
