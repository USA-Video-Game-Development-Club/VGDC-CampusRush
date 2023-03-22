//Author: Rhiannon Strickland
//Date: March 22, 2023
//Makes audio settings change and stored.

using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    [SerializeField]
    Slider mainSlider; //Main volume slider
    [SerializeField]
    TextMeshProUGUI mainValue; //Main volume indicator
    [SerializeField]
    Slider musicSlider; //Music volume slider
    [SerializeField]
    TextMeshProUGUI musicValue; //Music volume indicator
    [SerializeField]
    Slider effectsSlider; //Sound effects volume slider
    [SerializeField]
    TextMeshProUGUI effectsValue; //Sound effects volume indicator

    private void Start()
    {
        //Setting up the main slider
        mainSlider.maxValue = 100;
        mainSlider.value = PlayerPrefs.GetFloat("MainVolume", 100);
        mainValue.text = mainSlider.value + "%";
        //Setting up the music slider
        musicSlider.maxValue = 100;
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 100);
        musicValue.text = musicSlider.value + "%";
        //Setting up the sound effects slider
        effectsSlider.maxValue = 100;
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 100);
        effectsValue.text = effectsSlider.value + "%";
    }
    //These three functions are attached to their corresponding sliders and are called
    //whenever the corresponding slider changes.
    public void OnMainVolumeChanged()
    {
        PlayerPrefs.SetFloat("MainVolume", mainSlider.value);
        mainValue.text = mainSlider.value + "%";
    }
    public void OnMusicVolumeChanged()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        musicValue.text = musicSlider.value + "%";
    }
    public void OnEffectsVolumeChanged()
    {
        PlayerPrefs.SetFloat("EffectsVolume", effectsSlider.value);
        effectsValue.text = effectsSlider.value + "%";
    }
}
