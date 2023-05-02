using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;
    private float horizontalInput;
    private Animator anim;
    private player playerMovement;
    [SerializeField] private float attackCoolDown;
    private float cooldownTimer = Mathf.Infinity;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<player>();
    }
    private void Update()
    {

        //  if(Input.GetKeyDown(KeyCode.Return)) {
        //if (Input.GetMouseButton(0) & playerMovement.canAttack()==false & cooldownTimer>attackCoolDown) { 
        if (Input.GetKeyDown(KeyCode.Space) & playerMovement.canAttack()==false & cooldownTimer>attackCoolDown) { 
            Shoot();
        }
        cooldownTimer += Time.deltaTime;
    }
   
    void Shoot()
    {
        if(!canShoot) {
            return;
        }
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        GameObject it=Instantiate(shootingItem, shootingPoint);
        it.transform.parent = null;
    }
}
