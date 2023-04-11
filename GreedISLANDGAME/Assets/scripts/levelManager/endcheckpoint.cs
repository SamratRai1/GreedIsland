
using UnityEngine;
using UnityEngine.SceneManagement;
public class endcheckpoint : MonoBehaviour
{
    public int nextSceneload;
    // Start is called before the first frame update
    private void Start()
    {
        nextSceneload = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            {
                if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    Debug.Log("Game Ends");
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
