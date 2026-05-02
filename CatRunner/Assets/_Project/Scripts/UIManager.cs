using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Canvas Delay Settings")]
    [SerializeField] private Canvas canvasDelay;
    [SerializeField] private Text textDelay;

    [Header("Canvas HUD")]
    [SerializeField] private Text fishCoinNumberText;
    [SerializeField] private Canvas HUD;
    
    void Start()
    {
        canvasDelay.enabled = true;
        HUD.enabled = false;
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
}
