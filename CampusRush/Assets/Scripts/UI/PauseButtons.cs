using UnityEditor;
using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    [SerializeField]
    GameObject settings;
    [SerializeField]
    GameObject root;

    public void Resume()
    {
        settings.GetComponent<SettingsMenu>().setRoot();
        settings.SetActive(false);
        this.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void SettingsButton()
    {
        root.SetActive(false);
        settings.SetActive(true);
    }
    public void MainMenu()
    {
        SceneChanger.instance.MainMenu();
    }
    public void Back()
    {
        root.SetActive(true);
        settings.SetActive(false);
    }
}
