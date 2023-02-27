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
    private Animator anim;
    public AudioClip deathClip;
    public AudioClip enemy1Shot;
    private bool alreadyCounted = false;
    
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
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if(shootTimer > coolDownTime)
        {
            shootTimer = 0;
            Instantiate(enemyBullet, enemy1Gun.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(enemy1Shot, transform.position);
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
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("bullet") || col.gameObject.tag.Equals("pistolBullet") || col.gameObject.tag.Equals("rocket"))
        {
            if(!alreadyCounted)
            {
                scoreScript.scoreValue += 15;
                alreadyCounted = true;
            }
            Destroy(col.gameObject);
            anim.SetTrigger("onDeath");
            speed = 0;
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(gameObject, 0.25f);
            
        }

        if (col.gameObject.tag.Equals("player"))
        {
            anim.SetTrigger("onDeath");
            speed = 0;
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(gameObject, 0.25f);
        }
        
    }
}
