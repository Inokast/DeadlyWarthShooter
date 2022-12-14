using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting

public class EnemyProjectile : MonoBehaviour
{
    [Header("Bolt Values")]
    [SerializeField] float boltSpeed;
    [SerializeField] float destroyTime;
    public int damageAmt;
    Rigidbody2D rb;
    Transform player;
    Vector2 targetDir;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (gameObject.tag == "projectile/bolt")
        {
            ShootAtTarget();
        }
    }

    void Update()
    {
        if(gameObject.tag == "projectile/missile")
        {
            SeekTarget();
        }
        if (!player.gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, destroyTime);
    }

    //determine reaction based on what is hit (usually the player)
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log($"Hit {player.gameObject.name}, player's health is: {player.GetComponent<PlayerStats>().HP}");
        }
    }

    //shoot towards player when instantiated
    void ShootAtTarget()
    {
        if(player != null)
        {
            targetDir = (player.position - transform.position).normalized * boltSpeed;
            rb.velocity = new Vector2(targetDir.x, targetDir.y);
        }
    }

    //this will literally seek out the player before its destruction-- could be for a missile type weapon?- T.E.
    void SeekTarget()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, boltSpeed * Time.deltaTime);
        }
    }
}
