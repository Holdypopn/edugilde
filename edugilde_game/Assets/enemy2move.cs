using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2move : MonoBehaviour
{
    public float speed = 26;
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
       transform.Translate(speed * Time.deltaTime * Vector2.left); 
    }
}