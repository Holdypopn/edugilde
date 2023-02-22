using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suicideEnemyHandling : MonoBehaviour
{
    private GameObject target;
    public float speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("POS: " + target.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    // Destroy enemy, when leaving the screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
