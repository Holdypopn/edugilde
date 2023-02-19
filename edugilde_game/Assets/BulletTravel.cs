using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{   
    public float speed = 2;
    internal void destroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void Awake() 
    {
        Invoke("destroySelf", 2);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        destroySelf();
    }
}
