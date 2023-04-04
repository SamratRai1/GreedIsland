using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    private Animator anim;
    private player playerMovement;
    private float cooldownTimer =Mathf.Infinity;
    // Start is called before the first frame update
    private void Awake()
    {
        anim=GetComponent<Animator>();
        playerMovement = GetComponent<player>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer> attackCoolDown && playerMovement.canAttack() )
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack")  ;
        cooldownTimer = 0;
        arrows[0].transform.position = firePoint.position;
        arrows[0].GetComponent<projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
