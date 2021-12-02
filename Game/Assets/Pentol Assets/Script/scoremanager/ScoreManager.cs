using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public Text CoinUI;
    int score, coins;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
           instance = this;
        }
        GetCoins();
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "X"+ score.ToString();
    }

    public void GetCoins()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        else
        {
            coins = 0;
        }
        // set UI text by collected coins
        CoinUI.text = coins.ToString();
    }

}
