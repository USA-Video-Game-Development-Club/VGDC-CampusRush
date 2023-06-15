using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour{
    public GameObject menu;
    // Start is called before the first frame update
    void Start(){
        PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update(){
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && !other.isTrigger){
            menu.SetActive(!menu.activeSelf);
            if (!menu.activeSelf) Time.timeScale = 1.0f;
            else Time.timeScale = 0;
        }
    }
}
