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
    public CapsuleCollider2D capsuleCollider2D;
    private bool alreadyCounted = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("player");
        anim = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
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

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag.Equals("bullet") || col.gameObject.tag.Equals("pistolBullet") || col.gameObject.tag.Equals("rocket"))
        {
            if(!alreadyCounted)
            {
                scoreScript.scoreValue += 15;
                alreadyCounted = true;
            }
            capsuleCollider2D.enabled = false;
            anim.SetTrigger("onDeath");
            speed = 0;
            Instantiate(lifeDrop, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(gameObject, 0.25f);            
        }

        if (col.gameObject.tag.Equals("player"))
        {
            capsuleCollider2D.enabled = false;
            anim.SetTrigger("onDeath");
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(gameObject, 0.25f);
        }
        
    }
}
