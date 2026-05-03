
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
    [SerializeField] private Button pauseButton, closePauseScreenButton, restartButton, backToMenuButton, quitButton;
    [SerializeField] private GameObject pausePanel;

    [Header("Canvas Lose Screen")]
    [SerializeField] private Canvas LoseScreen;

    [SerializeField] private CheckCollision checkCollision;
    [SerializeField] private Button lSPlayAgainButton, lSBackToMenu, lSQuitGame;
    [SerializeField] private Text textHighScoreNumber; 


    
    void Start()
    {
        Time.timeScale = 1.0f;

        canvasDelay.enabled = true;
        HUD.enabled = false;
        LoseScreen.enabled = false;
        
        pausePanel.SetActive(false);


        pauseButton.onClick.AddListener(PauseGame);
        closePauseScreenButton.onClick.AddListener(ClosePauseScreen);
        restartButton.onClick.AddListener(RestartGame);
        backToMenuButton.onClick.AddListener(BackToMenu);
        quitButton.onClick.AddListener(QuitGame);

        lSPlayAgainButton.onClick.AddListener(PlayAgain);
        lSBackToMenu.onClick.AddListener(BackToMenu);
        lSQuitGame.onClick.AddListener(QuitGame);
    }

    

    void Update()
    {

        EnableLoseScreen();
        HighScoreUpdate();


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

    private void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
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
    private void QuitGame()
    {
      Application.Quit();   
    }



    private void EnableLoseScreen()
    {
        if (checkCollision.isDead == true)
        {
            LoseScreen.enabled = true;
            Time.timeScale = 0.0f;
        }
    }
    private void HighScoreUpdate()
    {
        textHighScoreNumber.text = GameManager.highscore.ToString();
    }


}
