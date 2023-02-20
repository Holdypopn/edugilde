using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnright1 : MonoBehaviour
{
    public Transform spawnright;
    public GameObject enemy2;
    public float respawnTime = 15;
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
            Instantiate(enemy2, spawnright.position, Quaternion.identity);
        }
    }

}
