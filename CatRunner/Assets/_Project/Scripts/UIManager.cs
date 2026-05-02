using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Canvas Delay Settings")]
    [SerializeField] private Canvas canvasDelay;
    [SerializeField] private Text textDelay;

    [Header("Canvas HUD")]
    [SerializeField] private Text fishCoinNumberText;
    [SerializeField] private Canvas HUD;
    [SerializeField] private Button pauseButton, closePauseScreenButton, restartButton, quitButton;
    [SerializeField] private GameObject pausePanel;
    
    void Start()
    {
        canvasDelay.enabled = true;
        HUD.enabled = false;
        pausePanel.SetActive(false);


        pauseButton.onClick.AddListener(PauseGame);
        closePauseScreenButton.onClick.AddListener(ClosePauseScreen);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(BackToMenu);
    }

    

    void Update()
    {
        if (!GameManager.inGame)
        {
            textDelay.text = GameManager.delayStartGame.ToString();

            if(GameManager.delayStartGame == 0)
            {
                textDelay.text = "GO!"; 
            }
        }
        else
        {
            canvasDelay.enabled = false;
            HUD.enabled = true;
            CoinUpdate();
        }

    }


    void CoinUpdate()
    {
        fishCoinNumberText.text = GameManager.fishCoins.ToString();
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
        
    }
    private void ClosePauseScreen()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void RestartGame()
    {
        GameManager.fishCoins = 0;
        SceneManager.LoadScene("GameScene");
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
