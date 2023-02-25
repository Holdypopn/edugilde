using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHandling : MonoBehaviour
{
    public float moveSpeed = 1;
    public int lives = 50;
    public float cannonCoolDownTime = 1;
    public GameObject enemyBullet;
    public Transform cannonLeft;
    public Transform cannonRight;
    public GameObject laserGun;

    private float xBorder;
    private float yBorder;
    private Vector3 stageDimensions;
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private bool direction;
    private float maxDist = 10;
    private float minDist = -10;
    private float shootTimer;
    private float laserFireRate;
    private float laserCanFire = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 18)
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.down);
        else
        {
            switch (direction)
            {
                case true:
                    if(transform.position.x > minDist)
                        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                    else
                        direction = false;
                    break;
                case false:
                    if(transform.position.x < maxDist)
                        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                    else
                        direction = true;
                    break;
                default:
            }
        }

        shootTimer += Time.deltaTime;

        if(shootTimer > cannonCoolDownTime)
        {
            shootTimer = 0;
            Instantiate(enemyBullet, cannonLeft.position, Quaternion.identity);
            Instantiate(enemyBullet, cannonRight.position, Quaternion.identity);
        }

        if(Time.time > laserCanFire)
        {
            laserFireRate = Random.Range(2, 4);
            laserCanFire = Time.time + laserFireRate;
            laserGun.SetActive(true);
        }
    }
}
