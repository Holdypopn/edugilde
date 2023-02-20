using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1move : MonoBehaviour
{
    public float speed = 8;
    public GameObject player;
    private bool direction;
    void OnBecameInvisible() 
    {
         Destroy(gameObject);
    }
    internal void destroySelf()
    {
        gameObject.SetActive(false);
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
        destroySelf();
    }
}
