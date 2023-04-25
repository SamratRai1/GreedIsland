using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager =GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void LevelSelect()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Settings()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        SceneManager.LoadScene("Settingss");
    }
    public void GameQuit()
    {

        audioManager.PlayeSfx(audioManager.buttonSelect);
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            PlayerPrefs.DeleteAll();
        }
    }
}
