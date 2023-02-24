using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suicideEnemyHandling : MonoBehaviour
{
    private GameObject target;
    public float speed = 10;
    public GameObject lifeDrop;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("player");
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
        
        if (collision.gameObject.tag.Equals("bullet"))
        {
            scoreScript.scoreValue += 15;
            Instantiate(lifeDrop, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("player"))
        {
            Destroy(gameObject);
        }
        
    }
}
