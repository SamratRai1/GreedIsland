using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanel : MonoBehaviour
{
    public GameObject resetPanel;
    public GameObject audioPanel;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void MainMenu()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        resetPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
    public void Reset()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        resetPanel.SetActive(true);
        audioPanel.SetActive(false);
    }
    public void resetAgreed()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        PlayerPrefs.DeleteAll();
        resetPanel.SetActive(false);
        audioPanel.SetActive(true);
    }
    public void resetCancel()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        resetPanel.SetActive(false);
        audioPanel.SetActive(true);
    }
    public void audioset()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        resetPanel.SetActive(false);
        audioPanel.SetActive(true);
    }

}
