using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
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
}
