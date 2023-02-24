using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHandling : MonoBehaviour
{
    public float speed = 12;
    private Rigidbody2D Player;
    private Vector3 stageDimensions;
    private float xBorder;
    private float yBorder;
    public int lives = 3;
    public GameObject lifePics;
    public GameObject lifeDrop;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();

        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        // Could change the "1" to half player size
        xBorder = stageDimensions.x - 1;
        yBorder = stageDimensions.y - 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Player Input Movement
        var horizontalInput = Input.GetAxis("Horizontal") * speed;
        var verticalInput = Input.GetAxis("Vertical") * speed;
        Player.velocity = new Vector2(horizontalInput, verticalInput);

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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("enemyBullet") || collision.gameObject.tag.Equals("suicideEnemy") || collision.gameObject.tag.Equals("enemy1"))
        {
            Destroy(collision.gameObject);
            lives--;
            DeleteLifePic();

            if (lives <= 0)
            {    
                Destroy(gameObject);
                SceneManager.LoadScene(0); //Loads Main Menu
            }            
        }
    }
}