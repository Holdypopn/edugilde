using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandling : MonoBehaviour
{

    private CharacterController Player;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Move = Vector3.zero;
        Move.x = Input.GetAxis("Horizontal") * speed;
        Move.y = Input.GetAxis("Vertical") * speed;
        Player.Move(Move * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hallo");
        if (collision.gameObject.tag.Equals("enemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this);
        }
        
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("hallo");
        Destroy(hit.collider.gameObject);
        Destroy(this);
    }


}
