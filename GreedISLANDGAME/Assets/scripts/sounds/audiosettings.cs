using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class audiosettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSfxVolume();
        }
    }
    public void SetMusicVolume()
    {
        float mvolume = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(mvolume) *20);

        PlayerPrefs.SetFloat("musicVolume", mvolume);
    }
    public void SetSfxVolume()
    {
        float sfxvolume = sfxSlider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxvolume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sfxvolume);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetMusicVolume();
        SetSfxVolume();
    }
}
