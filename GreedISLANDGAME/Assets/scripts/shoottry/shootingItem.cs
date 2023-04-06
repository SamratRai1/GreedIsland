
using UnityEngine;

public class shootingItem : MonoBehaviour
{
    public float speed;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        if (collision.GetComponent<shootAction>())
             collision.GetComponent<shootAction>().Action();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject objects = GameObject.FindGameObjectWithTag("Player");
        player player = objects.GetComponent<player>();
        transform.Translate(transform.right * transform.localScale.x * player.Arrowspeed * Time.deltaTime);
    }
    
}

