using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyManager manager;
    [Header("Base Values")]
    GameObject player;
    Rigidbody2D rb;
    Health enemyHealth;
    [SerializeField] int eHealthAmt;
    [SerializeField] float enemySpeed;
    [SerializeField] float disToPlayer = 1f;
    [SerializeField] float shootingRange;

    [Header("Shooting Values")]
    [SerializeField] GameObject bolt;
    [SerializeField] float shotRate;
    float nextShot;


    void Start()
    {
        enemyHealth = new Health();
        enemyHealth._Health = eHealthAmt;

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        nextShot = Time.time;

    }

    void FixedUpdate()
    {
        ChasePlayer();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= shootingRange)
        {
            ShootProjectile();
        }
        // Dan Note: I felt like checking if the enemy was dead every frame was a bit much. I made TakeDamage() to check only when it has to take damage.
        Vector3 facing = player.transform.position - transform.position;
        float angle = Mathf.Atan2(facing.y, facing.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void ChasePlayer()
    {
        if(Vector2.Distance(transform.position, player.transform.position) > disToPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.transform.position) <= disToPlayer)
        {
            rb.velocity = Vector2.zero;
            Debug.Log("Enemy is engaging player");
        }
    }

    private void TakeDamage( float amount) 
    {
        enemyHealth._Health = enemyHealth._Health - amount;

        if (enemyHealth._Health <= 0)
        {
            Destroy(this.gameObject);
            manager.numEnemies--;
        }
    }

    void ShootProjectile()
    {
        if (Time.time > nextShot)
        {
            GameObject boltClone;
            boltClone = Instantiate(bolt, transform.position, Quaternion.identity);
            nextShot = Time.time + 1f / shotRate;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag=="projectile/bolt" )
        {
            Destroy(other.gameObject);
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);
            
        }
        if (other.collider.tag == "projectile/missile")
        {
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);
            Destroy(other.gameObject);
        }
    }
}
