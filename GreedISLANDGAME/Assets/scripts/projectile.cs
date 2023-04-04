using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float direction;
    // Start is called before the first frame update
   
    private void Awake()
    {
        anim= GetComponent<Animator>();
        boxCollider= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime*direction;
        transform.Translate(movementSpeed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("hit");

    }
    public void SetDirection(float _direction)
    { 
        direction = _direction;
        gameObject.SetActive(true);
        hit= false;
        boxCollider.enabled = true;
        float loacalScaleX=transform.localScale.x;
        if (Mathf.Sign(loacalScaleX) != _direction)
            loacalScaleX = -loacalScaleX;
        transform.localScale = new Vector3(loacalScaleX, transform.localScale.y,transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
