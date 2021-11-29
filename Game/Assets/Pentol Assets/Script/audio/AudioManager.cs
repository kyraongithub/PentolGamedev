using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    // play bgm
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    [SerializeField] Text soundOn;
    [SerializeField] Text soundOff;
    public bool muted = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateUIButton();
        AudioListener.pause = muted;
    }
    public void OnButtonPress()
    {
        if(!muted)
        {
            muted = true;
            AudioListener.pause = true ;
        } else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateUIButton();
    }
    private void UpdateUIButton()
    {
        if (!muted)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;
        } else
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }


}
