using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class BulletTravel : MonoBehaviour
{   
    public float speed = 2;
    public Vector2 direction;
    public Rigidbody2D rigidBody;
    private float angle;
    public float angleChangingSpeed = 3;
    private Vector2 lastPosition;
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

    }

    // Called 50 times per second -> better when handling physic objects
    void FixedUpdate ()
	{
        if(gameObject.tag.Equals("rocket"))
        {
            var enemy1List = GameObject.FindGameObjectsWithTag("enemy1");
            var suicideEnemyList = GameObject.FindGameObjectsWithTag("suicideEnemy");
            
            List<Transform> enemies = new List<Transform>();

            foreach (var item in enemy1List)
            {
                enemies.Add(item.transform);
            }
            foreach (var item in suicideEnemyList)
            {
                enemies.Add(item.transform);
            }
            var boss = GameObject.FindGameObjectsWithTag("boss");
            enemies.Add(boss[0].transform);

            if(enemies.Any())
            {
                var target = GetClosestEnemy(enemies);

                Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
                angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                transform.rotation = Quaternion.Euler (0f, 0f, angle);
                lastPosition = transform.position;
                if (Vector2.Distance(((Vector2)target.position), rigidBody.position) >= 1.0f)
                {
                    rigidBody.velocity = transform.up * speed;
                } else
                {
                    rigidBody.velocity = -1 * transform.up * speed;
                }
            }
            else
            {
                transform.Translate(speed * Time.deltaTime * direction);
            }
        }
        else
        {
            transform.Translate(speed * Time.deltaTime * direction);
        }
	}

    Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        for (int i = 0; i < enemies.Count; i++)
        {
            Vector3 directionToTarget = enemies[i].position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = enemies[i];
            }
        }

        return bestTarget;
    }
}
