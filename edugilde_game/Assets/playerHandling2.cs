using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandling2 : MonoBehaviour
{
    public float speed = 12;
    private Rigidbody2D Player;
    
    // Start is called before the first frame update
    void Start()
    {
         Player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal") * speed;
        var verticalInput = Input.GetAxis("Vertical") * speed;
        Player.velocity = new Vector2(horizontalInput, verticalInput);
    }
}