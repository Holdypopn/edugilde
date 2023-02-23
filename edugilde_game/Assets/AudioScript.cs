using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioScript : MonoBehaviour 
{
    public AudioMixer masterMixer;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider gunshots;
    [SerializeField] TMP_Text gunshotText;

    void Start()
    {
        gunshots.onValueChanged.AddListener(delegate {SetMasterSound(); });
        SetStartingValues();
    }

    public void SetMasterSound()
    {
        audioMixer.SetFloat("gunshotVol", gunshots.value);
        float percentage = (((-80.0f - gunshots.value)) / -80.0f) * 100.0f;
        gunshotText.text = ((int)percentage).ToString();
    }

    void SetStartingValues()
    {
        float percentage, value;

        audioMixer.GetFloat("gunshotVol", out value);
        gunshots.value = value;
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;
        gunshotText.text = ((int)percentage).ToString();
    }        
}