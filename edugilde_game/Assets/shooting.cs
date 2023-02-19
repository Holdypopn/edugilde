using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform gun;
    public GameObject bullet;
    public float coolDownTime = 1;
    private float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if(shootTimer > coolDownTime && Input.GetKey(KeyCode.Space))
        {
            shootTimer = 0;
            Instantiate(bullet, gun.position, Quaternion.identity);
        }
    }
}
