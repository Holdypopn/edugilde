using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform gun;
    public GameObject bullet;
    public float coolDownTime = 1;
    private float shootTimer = 0.1f;
    private weapon weapon;
    private pistol pistol;
    private machineGun machineGun;
    private rocketLauncher rocketLauncher;

    // Start is called before the first frame update
    void Start()
    {
        pistol = new pistol();
        
        machineGun = new machineGun();
        machineGun.projectile = bullet;

        rocketLauncher = new rocketLauncher();
    }


    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Alpha1))
        {
            pistol.getShootingConfig();
        }

        if(Input.GetKey(KeyCode.Alpha2))
        {

        }

        if(Input.GetKey(KeyCode.Alpha3))
        {

        }

        //shootTimer += Time.deltaTime;

        if(shootTimer > coolDownTime && Input.GetKey(KeyCode.Space))
        {
            shootTimer = 0;
            Instantiate(bullet, gun.position, Quaternion.identity);
        }
    }
}

public class weapon
{
    public float shootTimer;
    public float coolDownTime;
    public GameObject projectile;

    public GameObject getShootingConfig()
    {
        return projectile;
    }
}

public class pistol : weapon
{
    public pistol()
    {
        //shootTimer
        //coolDownTime
        //bullet prefab
    }
}

public class machineGun : weapon
{
    public machineGun()
    {
        shootTimer = 0.1f + Time.deltaTime;
        coolDownTime = 1;
    }
}

public class rocketLauncher : weapon
{
    public rocketLauncher()
    {
        //shootTimer
        //coolDownTime
        //bullet prefab
    }
}