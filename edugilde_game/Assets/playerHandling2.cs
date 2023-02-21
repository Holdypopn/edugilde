using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandling2 : MonoBehaviour
{
    public float speed = 12;
    private Rigidbody2D Player;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
         Player = GetComponent<Rigidbody2D>();
         Vector3 minScreenBounce = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
         Vector3 maxScreenBounce = cam.ScreenToWorldPoint(new Vector3(11, 11, 0));
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal") * speed;
        var verticalInput = Input.GetAxis("Vertical") * speed;
        Player.velocity = new Vector2(horizontalInput, verticalInput);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("enemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}