using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getCoin : MonoBehaviour
{

    public Text CoinUI;
    int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetCoins();
    }


    public void GetCoins()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        // set UI text by collected coins
        CoinUI.text = coins.ToString();
    }
}
