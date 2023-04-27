using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerLevel : MonoBehaviour
{
    AudioManager audioManager;
    public Button[] lvlButtons;
    private int levelAT;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update

    void Start()
    {
        levelAT = PlayerPrefs.GetInt("LevelUnlocked", 3);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 3 > levelAT)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }
    public void Level1()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
        canvasloader();
    }
    public void Level2()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        canvasloader();
    }
    public void Level3()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        canvasloader();
    }
    public void MainMenu()
    {
        audioManager.PlayeSfx(audioManager.buttonSelect);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1 );
    }
    private void canvasloader()
    {
        GameObject objToReactivate = GameObject.FindGameObjectWithTag("GameCanvas");
        if (objToReactivate != null)
        {
            objToReactivate.SetActive(true);
        }
    }

}
