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
    public float respawnTime1 = 1;
    public float respawnTime2 = 15;
    private float respawnCooldown1;
    private float respawnCooldown2;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        respawnCooldown1 += Time.deltaTime;
        if(respawnCooldown1 > respawnTime1)
        {
            respawnCooldown1 = 0;
            float r = Random.Range(-6, 10);
            Vector3 v = new Vector3(0, r, 0);

            List<Vector3> list = new List<Vector3>();
            list.Add(spawnLeft.position);
            list.Add(spawnRight.position);
            int index = Random.Range(0, 2);

            Instantiate(enemy1, (list[index] + v) , Quaternion.identity);
        }

        respawnCooldown2 += Time.deltaTime;
        if(respawnCooldown2 > respawnTime2)
        {
            respawnCooldown2 = 0;
            Instantiate(enemy2, spawnRight.position, Quaternion.identity);
        }
    }
}