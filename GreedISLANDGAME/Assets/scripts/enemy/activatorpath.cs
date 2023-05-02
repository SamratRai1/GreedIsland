using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class activatorpath : MonoBehaviour
{
    public GameObject path;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
    }
    private void Start()
    {
        path.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerarrow")
        {
            audioManager.PlayeSfx(audioManager.enemydeath);
            path.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    
}
