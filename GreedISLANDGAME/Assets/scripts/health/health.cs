using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float CurrentHealth { get; private set; }
    private Animator anim;
    public GameObject deatPanel;
    public Button PauseButton;
    private bool dead;
    AudioManager audioManager;
   
     public float startHealth()
    {
        return startingHealth;
    }

    private void Awake()
    {
        CurrentHealth = startingHealth;
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    public void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, startingHealth);
        if (CurrentHealth <1)
        {
            
            //player dead
            if (!dead) {
                //anim.SetTrigger("die");
                GetComponent<player>().enabled= false;
                GetComponent<shooting>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                //transform.position = transform.position;
                dead = true;
                deatPanel.SetActive(true);
                PauseButton.interactable = false;
                anim.SetTrigger("die");
                
            }
          
        }
    }
    public void AddHealth(float _value)
    {
        
        CurrentHealth =Mathf.Clamp(CurrentHealth+_value, 0, startingHealth);
        if (_value > 0)
        {
            audioManager.PlayeSfx(audioManager.playerHeal);
        }
    }
    public void ReplayLevel()
    {
        audioManager.PlayeSfx(audioManager.resume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseButton.interactable = true;
        Time.timeScale = 1;
    }
    public void MainMenus()
    {
        GameObject objToDeactivate = GameObject.FindGameObjectWithTag("GameCanvas");
        if (objToDeactivate != null)
        {
            objToDeactivate.SetActive(false);
        }
        audioManager.PlayeSfx(audioManager.buttonSelect);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
