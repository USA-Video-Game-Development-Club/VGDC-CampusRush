using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    //This handles all the settings buttons. You just plug the various submenus into the spots and it should work.
    //All back buttons in the submenus will use this class's setRoot function.  
    [SerializeField]
    GameObject rootMenu;
    [SerializeField]
    GameObject audioMenu;
    [SerializeField]
    GameObject graphicsMenu;
    public void setRoot()
    {
        rootMenu.SetActive(true);
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(false);
    }
    public void setAudio()
    {
        rootMenu.SetActive(false);
        audioMenu.SetActive(true);
        graphicsMenu.SetActive(false);
    }
    public void setGraphics()
    {
        rootMenu.SetActive(false);
        audioMenu.SetActive(false);
        graphicsMenu.SetActive(true);
    }
}
