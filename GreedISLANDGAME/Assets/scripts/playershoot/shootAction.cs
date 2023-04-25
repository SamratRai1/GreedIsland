using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class shootAction : MonoBehaviour
{
    AudioManager audioManager;
    public UnityEvent action;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Action()
    {
        audioManager.PlayeSfx(audioManager.enemydeath);
        action.Invoke();
    }
}
