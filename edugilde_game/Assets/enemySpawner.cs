using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemySpawner : MonoBehaviour
{
    public Transform spawnLeft;
    public Transform spawnRight;
    public Transform spawnTop;
    public GameObject enemy1;
    public GameObject enemy2;
    public float respawnTime1 = 2.8f;
    public float respawnTime2 = 15;
    private float respawnCooldown1 = 0;
    private float respawnCooldown2 = 0;
    public Camera cam;
    public TextMeshProUGUI textMesh;

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
        
        if(scoreScript.scoreValue >= 100)
        {
            respawnTime1 = 2.4f;
            respawnTime2 = 12;
        }
        if(scoreScript.scoreValue >= 300)
        {
            respawnTime1 = 2;
            respawnTime2 = 9;
        }
        if(scoreScript.scoreValue >= 500)
        {
            respawnTime1 = 1.5f;
            respawnTime2 = 7;
        }
        if(scoreScript.scoreValue >= 800)
        {
            respawnTime1 = 1;
            respawnTime2 = 4;
        }
    }
    
}