using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    private Canvas setting;
    private bool showSetting = false;
  public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void settingModal()
    {
        if (!showSetting)
        {
            showSetting = true;
            setting.enabled = true;
        } else if (showSetting)
        {
            showSetting = false;
            setting.enabled = false;
        }
    }
}
