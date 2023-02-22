using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class shooting : MonoBehaviour
{
    public Transform gun;
    public GameObject bullet;
    public float coolDownTime = 1;
    private float shootTimer;
    public AudioClip gunshot;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if(shootTimer > coolDownTime && Input.GetKey(KeyCode.Space))
        {
            shootTimer = 0;
            Instantiate(bullet, gun.position, Quaternion.identity);
            audioSource.PlayOneShot(gunshot, 3);
        }
    }
}
