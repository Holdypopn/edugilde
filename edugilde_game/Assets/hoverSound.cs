using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using TMPro;

public class hoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip AudioClip ;
    private AudioSource audioSource ;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(audioSource == null)
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.PlayOneShot(AudioClip);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
