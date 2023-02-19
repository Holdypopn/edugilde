using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    private CharacterController enemy2;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy2 = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Move = Vector3.zero;
        Move.x = Input.GetAxis("Horizontal") * speed;
        enemy2.Move(Move * Time.deltaTime);
    }
}
