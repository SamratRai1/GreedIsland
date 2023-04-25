
using System.Collections;
using UnityEngine;

public class enemyshootingitemup : MonoBehaviour
{

    public float speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<shootAction>())
            collision.gameObject.GetComponent<shootAction>().Action();
        Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(Destroyer());
    }
    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(transform.up * transform.localScale.x * speed * Time.deltaTime);
        

    }
    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);

    }
}

