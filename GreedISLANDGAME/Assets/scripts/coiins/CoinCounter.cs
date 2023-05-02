using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;
    public int currentCoins = 0;
    AudioManager audioManager;
    void Awake()
    {
        instance = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("TotalCoins"))
        {
            currentCoins = PlayerPrefs.GetInt("TotalCoins");
        }
        coinText.text = ": " + currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        IncreaseCoins(v, audioManager);
    }

    public void IncreaseCoins(int v, AudioManager audioManager)
    {
        audioManager.PlayeSfx(audioManager.coinCollect);
        currentCoins += v;
        coinText.text=": "+currentCoins.ToString();
        PlayerPrefs.SetInt("TotalCoins", currentCoins);
    }
    public void DecreaseCoins(int v)
    {
        currentCoins -= v;
        coinText.text = ": " + currentCoins.ToString();
        PlayerPrefs.SetInt("TotalCoins", currentCoins);
    }
}
