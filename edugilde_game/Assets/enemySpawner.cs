using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public Transform spawnLeft;
    public Transform spawnRight;
    public Transform spawnTop;
    public GameObject enemy1;
    public GameObject enemy2;
    public float respawnTime1 = 3;
    public float respawnTime2 = 15;
    private float respawnCooldown1 = 0;
    private float respawnCooldown2 = 0;
    public Camera cam;
    float delayAndSpawnRate = 2;
    float timeUntilSpawnRateIncrease = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        respawnCooldown1 = 0;
        respawnCooldown2 = 0;
    }

    float Spawner(float respawnCooldown, float respawnTime, GameObject enemy)
    {
        respawnCooldown += Time.deltaTime;
        if(respawnCooldown > respawnTime)
        {
            respawnCooldown = 0;
            float r = Random.Range(-6, 10);
            Vector3 v = new Vector3(0, r, 0);

            List<Vector3> list = new List<Vector3>();
            list.Add(spawnLeft.position);
            list.Add(spawnRight.position);
            int index = Random.Range(0, 2);

            Instantiate(enemy, (list[index] + v) , Quaternion.identity);
        }
        return respawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        respawnCooldown1 = Spawner(respawnCooldown1, respawnTime1, enemy1);
        respawnCooldown2 = Spawner(respawnCooldown2, respawnTime2, enemy2);
    }
    
}