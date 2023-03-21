//Author: Rhiannon Strickland
//Date: March 21, 2023
//This is meant to handle all the functions of the game over screen.

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//MAKE SURE THIS STAYS IN THE CANVAS IN THE GAMEOVER SCENE!!!//
public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreValue;
    // Start is called before the first frame update
    void Start()
    {
        scoreValue.text = "Score: " + PlayerPrefs.GetInt("Score"); //This shows the score the player got at the end of their time.
    }

    public void Restart()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel")); //Restarts the last level they were on
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1); //Loads the main menu scene. Make sure the main menu scene is placed at 1 in the build settings. DO NOT MOVE IT!
    }
}
