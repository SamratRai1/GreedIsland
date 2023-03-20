using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    Animator anim;
    private bool grounded;
    // Start is called before the first frame update
  
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity=new Vector2(horizontalInput*speed,body.velocity.y);
        if (horizontalInput > 0.01f)
            transform.localScale =new Vector3(0.35476f, 0.35476f, 0.35476f);
        else if (horizontalInput < -.01f)
            transform.localScale = new Vector3(-0.35476f, 0.35476f, 0.35476f);
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
        anim.SetBool("isWalking", horizontalInput != 0);
        anim.SetBool("grounded",grounded);
        
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
 
}
