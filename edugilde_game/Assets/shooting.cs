using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform gun;
    public GameObject pistolProjectile;
    public GameObject machineGunProjectile;
    public GameObject rocketProjectile;
    private pistol pistol;
    private machineGun machineGun;
    private rocketLauncher rocketLauncher;
    private Config config;
    public AudioClip gunshot;
    public AudioClip machinegunShot;
    public AudioClip rocketShot;
    

    // Start is called before the first frame update
    void Start()
    {
        pistol = new pistol();
        pistol.config.projectile = pistolProjectile;
        
        machineGun = new machineGun();
        machineGun.config.projectile = machineGunProjectile;

        rocketLauncher = new rocketLauncher();
        rocketLauncher.config.projectile = rocketProjectile;

        config = new Config();
        config = pistol.getShootingConfig();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            config = pistol.getShootingConfig();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            config = machineGun.getShootingConfig();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            config = rocketLauncher.getShootingConfig();
        }

        config.shootTimer += Time.deltaTime;

        if(config.shootTimer > config.coolDownTime && Input.GetKey(KeyCode.Space))
        {
            config.shootTimer = 0;
            Instantiate(config.projectile, gun.position, Quaternion.identity);

            if(config.projectile == pistolProjectile)
            {
            AudioSource.PlayClipAtPoint(gunshot, transform.position);
            }
            if(config.projectile == machineGunProjectile)
            {
            AudioSource.PlayClipAtPoint(machinegunShot, transform.position);
            }
            if(config.projectile == rocketProjectile)
            {
            AudioSource.PlayClipAtPoint(rocketShot, transform.position);
            }
        }
    }
}

public struct Config
{
    public string name;
    public float shootTimer;
    public float coolDownTime;
    public GameObject projectile;
}

public class weapon
{
    public Config config;
    public Config getShootingConfig()
    {
        return config;
    }
}

public class pistol : weapon
{
    public pistol()
    {
        config.name = "pistol";
        config.shootTimer = 0.1f;
        config.coolDownTime = 0.5f;
    }
}

public class machineGun : weapon
{
    public machineGun()
    {
        config.name = "machineGun";
        config.shootTimer = 0.1f;
        config.coolDownTime = 0.1f;
    }
}

public class rocketLauncher : weapon
{
    public rocketLauncher()
    {
        config.name = "rocketLauncher";
        config.shootTimer = 0.1f;
        config.coolDownTime = 0.8f;
    }
}