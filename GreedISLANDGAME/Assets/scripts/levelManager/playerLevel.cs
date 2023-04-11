using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerLevel : MonoBehaviour
{
    public Button[] lvlButtons;
    private int levelAT;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    }
    public void Level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void Level3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1 );
    }

}
