using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHandling : MonoBehaviour
{
    public float speed = 12;
    private Rigidbody2D rb;
    private Vector3 stageDimensions;
    private float xBorder;
    private float yBorder;
    public int lives = 3;
    public GameObject lifePics;
    public GameObject lifeDrop;
    public GameObject deathUI;

    private bool isMoving;
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength;
    public float dashCooldown;
    private float dashCounter;
    private float dashCoolDownCounter;
    private Animator anim;
    private Vector2 moveInput;
    public AudioClip deathClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        activeMoveSpeed = speed;
        anim = GetComponent<Animator>();

        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        // Could change the "1" to half player size
        xBorder = stageDimensions.x - 1;
        yBorder = stageDimensions.y - 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Player Input Movement
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        rb.velocity = moveInput * activeMoveSpeed;

        // Dash Handling
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(dashCoolDownCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolDownCounter = dashCooldown;
            }
        }

        if(dashCoolDownCounter > 0)
            dashCoolDownCounter -= Time.deltaTime;



        // Player movement restrictions (borders)
        if(transform.position.x > xBorder)
            transform.position = new Vector3(xBorder, transform.position.y, 0);
        else if(transform.position.x < -xBorder)
            transform.position = new Vector3(-xBorder, transform.position.y, 0);

        if(transform.position.y > yBorder)
            transform.position = new Vector3(transform.position.x, yBorder, 0);
        else if(transform.position.y < -yBorder)
            transform.position = new Vector3(transform.position.x, -yBorder, 0);
    }

    void DeleteLifePic()
    {
        lifePics.transform.GetChild(lives).gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("lifeDrop"))
        {
            Destroy(col.gameObject);
            if(lives < 3)
            {
                lifePics.transform.GetChild(lives).gameObject.SetActive(true);
                lives++;
            }
        }
        if (col.gameObject.tag.Equals("enemyBullet") || col.gameObject.tag.Equals("suicideEnemy") || col.gameObject.tag.Equals("enemy1"))
        {
            Destroy(col.gameObject);
            lives--;
            DeleteLifePic();

            if (lives <= 0)
            {   
                anim.SetTrigger("onDeath");
                speed = 0; 
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
                Destroy(gameObject, 0.25f);
                deathUI.transform.gameObject.SetActive(true);
            }            
        }
        if (col.gameObject.tag.Equals("laser"))
        {
            lives--;
            DeleteLifePic();

            if (lives <= 0)
            {
                anim.SetTrigger("onDeath");
                speed = 0;
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
                Destroy(gameObject, 0.25f);
                deathUI.transform.gameObject.SetActive(true);
            }
        }
    }
}