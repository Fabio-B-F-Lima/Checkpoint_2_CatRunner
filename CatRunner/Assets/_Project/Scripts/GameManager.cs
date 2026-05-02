using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int delayStartGame = 3;
    public static bool inGame = false;
    public static int fishCoins;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(StartGame());
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
        print(fishCoins);
    }
}
