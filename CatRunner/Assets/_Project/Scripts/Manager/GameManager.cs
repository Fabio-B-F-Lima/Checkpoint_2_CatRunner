using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField] Transform playerTramsform;
    public static int delayStartGame = 3;
    public static bool inGame = false;
    public static int fishCoins = 0, coinHighscore = 0;
    public static int score, highScore;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(StartGame());
    }


    private void Update()
    {
        Score();
        SetCoinHighscore();
        SetHighScore();
    }

    IEnumerator StartGame()
    {
        while(delayStartGame > 0)
        {            
            yield return new WaitForSeconds(1.0f);
            delayStartGame--;
        }

        yield return new WaitForSeconds(1.0f);
        inGame = true;
    }        


    public void AddCoin( int c)
    {
        fishCoins += c;
       
    }

    public void SetCoinHighscore()
    {
        if (fishCoins > coinHighscore)
        {
            coinHighscore = fishCoins;
        }
    }

    public void SetHighScore()
    {
        if (score > highScore)
            highScore = score;
    }
    public void Score()
    {
        score = Mathf.FloorToInt(playerTramsform.position.z);
    }

}
