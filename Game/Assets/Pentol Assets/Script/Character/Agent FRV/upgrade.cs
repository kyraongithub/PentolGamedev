using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    int currentCoins = 0;
    float currentHealth;
    float currentDamage;
    public Text warn;

    private void Start()
    {
        warn.enabled = false;
        //set coin for testing
        //PlayerPrefs.SetInt("coins", 10000);
        // for reset
        /*
        PlayerPrefs.SetFloat("playerHealth", 3f);
        PlayerPrefs.SetFloat("playerDamage", 1f);
        PlayerPrefs.SetString("isInvicibleStart", "false");
        print("reset done");
        */
    }

    void Update()
    {
        // get coin
        if (PlayerPrefs.HasKey("coins"))
        {
            currentCoins = PlayerPrefs.GetInt("coins");
        }
        // get health
        if (PlayerPrefs.HasKey("playerHealth"))
        {
            currentHealth = PlayerPrefs.GetFloat("playerHealth");
        }
        else
        {
            currentHealth = 3f;
        }
        // get damage
        if (PlayerPrefs.HasKey("playerDamage"))
        {
            currentDamage = PlayerPrefs.GetFloat("playerDamage");
        }
        else
        {
            currentDamage = 1f;
        }
    }

    public void DamageUpgrade()
    {
        if (currentCoins >= 50 && currentDamage <= 5)
        {
            PlayerPrefs.SetFloat("playerDamage", currentDamage + 1f);
            PlayerPrefs.SetInt("coins", currentCoins - 50);
        }
        else if (currentCoins < 50)
        {
            warn.enabled = true;
            StartCoroutine(WarnStop());
        }
    }

    public void HealthUpgrade()
    {  
        if(currentCoins >= 100 && currentHealth <= 5)
        {
            PlayerPrefs.SetFloat("playerHealth", currentHealth + 1f);
            PlayerPrefs.SetInt("coins", currentCoins - 100);
        }
        else if (currentCoins < 100)
        {
            warn.enabled = true;
            StartCoroutine(WarnStop());
        }
    }


    public void Invicible()
    {
        if (currentCoins >= 100 && !PlayerPrefs.HasKey("isInvicibleStart"))
        {
            PlayerPrefs.SetString("isInvicibleStart", "true");
            PlayerPrefs.SetInt("coins", currentCoins - 100);
        }
        else if (currentCoins < 100)
        {
            warn.enabled = true;
            StartCoroutine(WarnStop());
        }
    }

    private IEnumerator WarnStop()
    {
        yield return new WaitForSeconds(3);
        warn.enabled = false;
    }
}
