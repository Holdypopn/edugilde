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
    public Transform laserGunPos;
    public GameObject laserGun;
    public int bossScoreTrigger = 1500;
    public AudioClip death;
    public AudioClip bullet;
    public AudioClip spawn;
    public AudioClip laser;
    [SerializeField] public GameObject victoryUI;

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
    private float laserCanFire = 1;
    private bool alreadyCounted = false;
    private Animator[] anims;
    private bool alreadyAnnihilate = false;

    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponentsInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
        direction = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreScript.scoreValue >= bossScoreTrigger)
        {
            if(transform.position.y > 18)
            {
                transform.Translate(moveSpeed * Time.deltaTime * Vector2.down);
                if(!alreadyAnnihilate)
                {
                    AudioSource.PlayClipAtPoint(spawn, transform.position);
                    alreadyAnnihilate = true;
                }
            }
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
                AudioSource.PlayClipAtPoint(bullet, transform.position);
            }

            if(transform.position.y <= 18)
            {
                if(Time.time > laserCanFire)
                {
                    laserFireRate = Random.Range(2, 5);
                    laserCanFire = Time.time + laserFireRate;
                    GameObject bossGigaLaser = Instantiate(laserGun, laserGunPos.position, Quaternion.identity);
                    bossGigaLaser.transform.parent = transform;
                    AudioSource.PlayClipAtPoint(laser, transform.position);
                    Destroy(bossGigaLaser, 1);
                }
            }
        }
        if (lives == 125)
        {
            cannonCoolDownTime = 0.7f;
            moveSpeed = 12;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("bullet") || col.gameObject.tag.Equals("pistolBullet") || col.gameObject.tag.Equals("rocket"))
        {
            lives--;
            Destroy(col.gameObject);

            if(lives <= 0)
            {
                AudioSource.PlayClipAtPoint(death, transform.position);
                if(!alreadyCounted)
            {
                scoreScript.scoreValue += 500;
                alreadyCounted = true;
            }
                moveSpeed = 0;
                anims[0].SetTrigger("onDeath");
                anims[1].SetTrigger("onDeath");
                Destroy(gameObject, 1.5f);
                victoryUI.transform.gameObject.SetActive(true);
            }
        }
    }
}
