using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D Rigidbodyrb;
    public float speed;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbodyrb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 dir = player.transform.position - transform.position;
        Rigidbodyrb.velocity= new Vector2(dir.x, dir.y).normalized*speed;
        float rotation=Mathf.Atan2(-dir.y, -dir.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation+180);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 6) {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Trap")
        {
            Destroy(gameObject);
        }
    }
}
