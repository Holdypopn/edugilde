using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BulletTravel : MonoBehaviour
{   
    public float speed = 2;
    public Vector2 direction;
    public AudioClip clip;
    internal void destroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnBecameInvisible() 
    {
         Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2), 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    
}
