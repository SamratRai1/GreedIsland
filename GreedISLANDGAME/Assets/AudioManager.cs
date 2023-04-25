using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    //public sound[] musicSounds, sfxSounds;
    //public AudioSource musicsource, sfxSource;
    
   
   
   
    [Header("------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SfxSource;

    [Header("-------Audio Clip---------")]
    public AudioClip background;
    public AudioClip playerAttack;
    public AudioClip playerDeath;
    public AudioClip playerJump;
    public AudioClip coinCollect;
    public AudioClip playerHeal;
    public AudioClip checkPoint;
    public AudioClip enemydeath;
    public AudioClip enemyshoot;
    public AudioClip buttonHover;
    public AudioClip buttonSelect;
    public AudioClip pause;
    public AudioClip resume;
    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            float mvolume = PlayerPrefs.GetFloat("musicVolume");
            audioMixer.SetFloat("music", Mathf.Log10(mvolume) * 20);
            PlayerPrefs.SetFloat("musicVolume", mvolume);
        }
        

    }
    public void PlayeSfx(AudioClip clip)
    {
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            float svalues = PlayerPrefs.GetFloat("sfxVolume");
            audioMixer.SetFloat("sfx", Mathf.Log10(svalues) * 20);
            PlayerPrefs.SetFloat("sfxVolume", svalues);
        }
        SfxSource.PlayOneShot(clip);
    }

}
