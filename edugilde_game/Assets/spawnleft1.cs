using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnleft1 : MonoBehaviour
{
    public Transform spawnleft;
    public GameObject enemy1;
    public float respawnTime = 5;
    private float respawnCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    


    // Update is called once per frame
    void Update()
    {
        respawnCooldown += Time.deltaTime;
        if(respawnCooldown > respawnTime)
        {
            respawnCooldown = 0;
            Instantiate(enemy1, spawnleft.position, Quaternion.identity);
        }
    }

}

