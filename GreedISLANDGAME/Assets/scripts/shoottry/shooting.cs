using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;
    private void Update()
    {

        //  if(Input.GetKeyDown(KeyCode.Return)) {
        if (Input.GetMouseButton(0)) { 
            Shoot();
        }
    }
    void Shoot()
    {
        if(!canShoot) {
            return;
        }
        GameObject it=Instantiate(shootingItem, shootingPoint);
        it.transform.parent = null;
    }
}
