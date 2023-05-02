using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemydeath : MonoBehaviour
{
    public int enemyLife;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerarrow")
        {
            audioManager.PlayeSfx(audioManager.enemydeath);
            enemyLife -= 1;
            if (enemyLife == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
