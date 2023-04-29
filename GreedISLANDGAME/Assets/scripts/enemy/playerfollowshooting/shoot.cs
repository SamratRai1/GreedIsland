using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    public float distance;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(transform.position, player.transform.position);
          
      
        if (dis < distance)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;

                shooot();
            }
        }
    }
    void shooot()
    {
        Instantiate(bullet,bulletPos.position,quaternion.identity);
    }
}
