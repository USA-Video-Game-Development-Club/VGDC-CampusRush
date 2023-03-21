//Author: Rhiannon Strickland
//March 21, 2023
//This script handles the main menu screen.
//This will expand to include the settings menu in time

using UnityEngine;
using UnityEngine.SceneManagement;

//Load the main menu scene in the scenes folder and you're good to go!
public class StartMenuScreen : MonoBehaviour
{
    //These functions are meant to be inserted into the buttons on the MainMenu scene.
    //Don't forget to put this on the canvas in the main menu scene.
    public void Play()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel", 2)); //Loads the last level the player was in
    }
    public void Exit()
    {
        Debug.Log("Quit the game"); // This is to check if the function is being called in the editor since the following statement does not.
        Application.Quit(); //Quits the application. This will not work in the editor, but I have tested this exact function in another game and it works as intended.
    }
}
