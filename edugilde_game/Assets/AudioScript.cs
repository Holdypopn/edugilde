using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioScript : MonoBehaviour 
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider soundSlider, musicSlider;
    [SerializeField] TMP_Text soundText, musicText;

    void Start()
    {
        soundSlider.onValueChanged.AddListener(delegate {SetsoundSound(); });
        musicSlider.onValueChanged.AddListener(delegate {SetmusicSound(); });
        SetStartingValues();
    }

    public void SetsoundSound()
    {
        audioMixer.SetFloat("soundVol", soundSlider.value);
        float percentage = (((60 + soundSlider.value)) / 80) * 100;
        soundText.text = ((int)percentage).ToString();
    }

    public void SetmusicSound()
    {
        audioMixer.SetFloat("musicVol", musicSlider.value);
        float percentage = (((60 + musicSlider.value)) / 80) * 100;
        musicText.text = ((int)percentage).ToString();
    }

    void SetStartingValues()
    {
        float percentage, value;

        audioMixer.GetFloat("soundVol", out value);
        soundSlider.value = value;
        percentage = ((60 + value) / 80) * 100;
        soundText.text = ((int)percentage).ToString();

        audioMixer.GetFloat("musicVol", out value);
        musicSlider.value = value;
        percentage = ((60 + value) / 80) * 100;
        musicText.text = ((int)percentage).ToString();
    }        
}