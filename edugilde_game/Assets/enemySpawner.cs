using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public Transform spawnleft1;
    public Transform spawnright1;
    public GameObject enemy1;
    public GameObject enemy2;
    public float respawnTime1 = 5;
    public float respawnTime2 = 15;
    private float respawnCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        respawnCooldown += Time.deltaTime;
        if(respawnCooldown > respawnTime1)
        {
            respawnCooldown = 0;
            Instantiate(enemy1, spawnleft1.position, Quaternion.identity);
        }
        respawnCooldown += Time.deltaTime;
        if(respawnCooldown > respawnTime2)
        {
            respawnCooldown = 0;
            Instantiate(enemy2, spawnright1.position, Quaternion.identity);
        }
    }

}