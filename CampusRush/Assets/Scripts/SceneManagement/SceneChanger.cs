//Author: Rhiannon Strickland
//Date: March 21, 2023
//This handles all the scene changes in a level.

using UnityEngine;
using UnityEngine.SceneManagement;

//DO NOT FORGET TO PUT THIS IN AN EMPTY OBJECT IN EACH LEVEL//
public class SceneChanger : MonoBehaviour
{
    //This region is to make this more easily accessible by other classes.
    //Make sure there is only one of these in any level at any given time.
    //Otherwise we have problems.
    //Collapse the region if you don't want to look at the details.
    //This is based off a singleton in the Brackeys RPG video for inventories.
    #region SINGLETON
    public static SceneChanger instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one of these out here!");
            return;
        }
        instance = this;
    }
    #endregion

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
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
