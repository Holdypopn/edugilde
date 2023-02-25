using System.Collections;
using System.Collections.Generic;
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
        if(gameObject.tag.Equals("rocket"))
        {
            /*var enemy1List = GameObject.FindGameObjectsWithTag("enemy1");
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

            var target = GetClosestEnemy(enemies);

            Debug.Log("TARGET: " + target.name);
            Debug.Log("TARGET POS: " + target.transform.position);

            Vector2 dir = new Vector2();
            dir.x = target.position.x;
            dir.y = target.position.y;

            transform.Translate(speed * Time.deltaTime * dir);*/
        }
        else
        {
            //transform.Translate(speed * Time.deltaTime * direction);
        }
    }

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
