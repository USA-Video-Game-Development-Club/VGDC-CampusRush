//Author: Rhiannon Strickland
//Date: March 21, 2023
//This handles all the scene changes in a level.

using UnityEngine;
using UnityEngine.SceneManagement;

//DO NOT FORGET TO PUT THIS IN AN EMPTY OBJECT IN EACH LEVEL//
public class SceneChanger : MonoBehaviour
{
    public void GameOver()
    {
        PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex); // This allows for the level to be kept track of
        SceneManager.LoadScene(0); //Loads the GameOver scene. Make sure the GameOver scene is at build index 0 in the build settings. DO NOT MOVE IT!
    }
    public void NextLevel()
    {
        //Loads the next level. Levels should be ordered as level 1 being 2, 2 being 3, etc.
        //Make sure that the scenes are in level order from TWO ONWARD, otherwise this won't work properly.
        //The last scene should likely be a game winning screen without this object, thus there won't be an overflow.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
