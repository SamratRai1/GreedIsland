using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;
    [SerializeField] private float attackCoolDown;
    private float cooldownTimer = Mathf.Infinity;

    public Transform player;
    public Transform self;
    private void Awake()
    {
      
    }
    private void Update()
    {
        float distance = Vector2.Distance(player.position, self.position);
      
        //  if(Input.GetKeyDown(KeyCode.Return)) {
        if (cooldownTimer>attackCoolDown & distance<8) { 
            Shoot();
        }
        cooldownTimer += Time.deltaTime;
    }
   
    void Shoot()
    {
        if(!canShoot) {
            return;
        }
       // anim.SetTrigger("shoot");
        cooldownTimer = 0;
        GameObject it=Instantiate(shootingItem, shootingPoint);
        it.transform.localScale = new Vector3(1, 1, 1);
        it.transform.parent = null;
    }
}
