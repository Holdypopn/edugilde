using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Handling : MonoBehaviour
{
    public float speed = 8;
    public GameObject player;
    private bool direction;
    public Transform enemy1Gun;
    public GameObject enemyBullet;
    public float coolDownTime = 5;
    private float shootTimer;
    
    void OnBecameInvisible() 
    {
         Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        if(player.transform.position.x > transform.position.x)
        {
            direction = true;
        }
        else
        {
            direction = false;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if(shootTimer > coolDownTime)
        {
            shootTimer = 0;
            Instantiate(enemyBullet, enemy1Gun.position, Quaternion.identity);
        }

        if(direction == true)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.right);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime * Vector2.left);
        }
    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.gameObject.tag.Equals("bullet"))
        {
            scoreScript.scoreValue += 10;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("player"))
        {
            Destroy(gameObject);
        }
        
    }
}
