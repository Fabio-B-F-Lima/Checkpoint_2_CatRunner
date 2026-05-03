using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int delayStartGame = 3;
    public static bool inGame = false;
    public static int fishCoins = 0, highscore = 0;

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
        SetHighscore();
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

    public void SetHighscore()
    {
        if (fishCoins > highscore)
        {
            highscore = fishCoins;
        }
    }
}
