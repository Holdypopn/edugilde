using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suicideEnemyHandling : MonoBehaviour
{
    private GameObject target;
    public float speed = 10;
    public GameObject lifeDrop;
    private Animator anim;
    public AudioClip deathClip;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    // Destroy enemy, when leaving the screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag.Equals("bullet") || collision.gameObject.tag.Equals("pistolBullet") || collision.gameObject.tag.Equals("rocket"))
        {
            anim.SetTrigger("onDeath");
            speed = 0;
            scoreScript.scoreValue += 15;
            Instantiate(lifeDrop, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(gameObject, 0.25f);
        }

        if (collision.gameObject.tag.Equals("player"))
        {
            anim.SetTrigger("onDeath");
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(gameObject, 0.25f);
        }
        
    }
}
