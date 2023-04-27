using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformfall : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(faller());
    }
    // Update is called once per frame
    IEnumerator faller()
    {
        anim.SetTrigger("fall");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
