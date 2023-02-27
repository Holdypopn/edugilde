using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicHandling : MonoBehaviour
{
    public AudioSource normalMusic;
    public AudioSource bossMusic;
    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("boss").Length != 0)
        {
            normalMusic.Stop();
            if(isPlaying)
            {
                bossMusic.Play();
                isPlaying = false;
            }
        }

        if(GameObject.FindGameObjectsWithTag("boss").Length == 0)
        {
            bossMusic.Stop();
            if(!isPlaying)
            {
                normalMusic.Play();
                isPlaying = true;
            }
        }
    }
}
