using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolASrc : MonoBehaviour{

    AudioSource aSrc;
    public bool music;
    public bool sfx;

    // Start is called before the first frame update
    void Start(){
        aSrc = GetComponent<AudioSource>();
        aSrc.volume = (PlayerPrefs.GetFloat("MainVolume",100)/100) * (music ? PlayerPrefs.GetFloat("MusicVolume",100)/100 : 1)  * (sfx ? PlayerPrefs.GetFloat("EffectsVolume",100)/100 : 1);
    }
}
