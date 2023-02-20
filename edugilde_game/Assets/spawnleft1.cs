using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnleft1 : MonoBehaviour
{
    public Transform spawnleft;
    public GameObject enemy1;
    public float coolDownTime = 20;
    private float respawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coolDownTime += Time.deltaTime;
        if(respawnTimer > coolDownTime)
        respawnTimer = 20;
        Instantiate(enemy1, spawnleft.position, Quaternion.identity);

    }
}

