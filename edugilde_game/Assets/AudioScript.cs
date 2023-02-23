using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioScript : MonoBehaviour 
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text volumeText;

    void Start()
    {
        slider.onValueChanged.AddListener(delegate {SetMasterSound(); });
        SetStartingValues();
    }

    public void SetMasterSound()
    {
        audioMixer.SetFloat("gunshotVol", slider.value);
        float percentage = (((60 + slider.value)) / 80) * 100;
        volumeText.text = ((int)percentage).ToString();
    }

    void SetStartingValues()
    {
        float percentage, value;

        audioMixer.GetFloat("gunshotVol", out value);
        slider.value = value;
        percentage = ((60 + value) / 80) * 100;
        volumeText.text = ((int)percentage).ToString();
    }        
}