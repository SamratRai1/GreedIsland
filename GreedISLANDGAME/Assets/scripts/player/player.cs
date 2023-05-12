using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    Animator anim;
    private bool grounded;
    private float horizontalInput;
    private Vector3 respawnPoint;
    //public GameObject Falldetector;
    public float Arrowspeed;
    public GameObject pausePanel;
    AudioManager audioManager;
    GameObject players;
    // Start is called before the first frame update
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint=transform.position;
        audioManager=GameObject.FindGameObjectWithTag("Audio").GetComponent <AudioManager>();
        players = GameObject.FindWithTag("Player");
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        //if (playerDead() != true)
        //{
            horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.35476f, 0.35476f, 0.35476f);
        }
        else if (horizontalInput < -.01f)
       
            {
            transform.localScale = new Vector3(-0.35476f, 0.35476f, 0.35476f);
        }
        if (Input.GetKey(KeyCode.W) && grounded)
        {
            Jump();

            audioManager.PlayeSfx(audioManager.playerJump);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
            anim.SetBool("isWalking", horizontalInput != 0);
            anim.SetBool("grounded", grounded);

        if (players != null)
        {
            health health = players.GetComponent<health>();
            if (health != null)
            {
                
                if (health.CurrentHealth < health.startHealth())
                {
                    CoinCounter coins=players.GetComponent<CoinCounter>();
                    if (coins.currentCoins > 100)
                    {
                        coins.DecreaseCoins(100);
                        health.AddHealth(1);
                    }
                }
            }
        }
    }
    private void Jump()
    {

        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "FallDetector" || collision.gameObject.tag == "Trap" )
        {
            audioManager.PlayeSfx(audioManager.playerDeath);
            transform.position = respawnPoint;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }
       
    }
    public bool canAttack()
    {
        horizontalInput = Input.GetAxis("Horizontal");
         if (horizontalInput == 0)
        //if (Input.GetKeyDown(KeyCode.P))
        {
            return false;
        }
        return true;
    }
    public void PauseGame()
    {
        audioManager.PlayeSfx(audioManager.pause);
       
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        audioManager.PlayeSfx(audioManager.resume);
        
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
