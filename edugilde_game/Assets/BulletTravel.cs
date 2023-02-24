using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletTravel : MonoBehaviour
{   
    public float speed = 2;
    public Vector2 direction;
    internal void destroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnBecameInvisible() 
    {
         Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    
}
