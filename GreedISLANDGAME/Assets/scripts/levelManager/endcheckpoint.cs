
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class endcheckpoint : MonoBehaviour
{
    private int nextSceneload;
    // Start is called before the first frame update
    private GameObject endpanel;
    public Button PauseButton;
    private void Start()
    {
        nextSceneload = SceneManager.GetActiveScene().buildIndex + 1;
        endpanel = GameObject.FindWithTag("EndPanel");
        if (endpanel != null)
        {
            endpanel.SetActive(false);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            {
                if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    if (endpanel != null)
                    {
                        PauseButton.interactable = false;
                        Time.timeScale = 0;
                        endpanel.SetActive(true);

                    }

                }
                else
                {
                    SceneManager.LoadScene(nextSceneload);
                    if (PlayerPrefs.GetInt("LevelUnlocked") < nextSceneload)
                    {
                        PlayerPrefs.SetInt("LevelUnlocked", nextSceneload);
                    }
                    collision.gameObject.GetComponent<player>().enabled = false;
                    collision.gameObject.GetComponent<shooting>().enabled = false;
                }
            }

        }
    }
}
