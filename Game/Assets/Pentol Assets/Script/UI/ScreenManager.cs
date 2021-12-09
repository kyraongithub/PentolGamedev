using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public Canvas setting;
    public bool showSetting = false;
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
    public string getActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
