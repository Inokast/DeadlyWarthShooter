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
    [SerializeField] float eHealthAmt;
    [SerializeField] float enemySpeed;
    [SerializeField] float disToPlayer = 1f;
    [SerializeField] float shootingRange;
    [SerializeField] int scoreValue;

    [Header("Shooting Values")]
    [SerializeField] GameObject bolt;
    [SerializeField] GameObject[] cannon;
    [SerializeField] float shotRate;
    float nextShot;
    public Transform thisObject;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        nextShot = Time.time;
        thisObject.parent = null;
        manager = EnemyManager.FindObjectOfType<EnemyManager>();

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

    private void TakeDamage(float amount) 
    {
        eHealthAmt -= amount;

        if (eHealthAmt <= 0)
        {
            Destroy(gameObject);
            GameManager.gm.IncrementScore(scoreValue);
            manager.numEnemies--;
            manager.EnemyChecker();
        }
    }

    void ShootProjectile()
    {
        if (Time.time > nextShot)
        {
            foreach(GameObject c in cannon)
            {
                GameObject boltClone;
                boltClone = Instantiate(bolt, c.transform.position, Quaternion.identity);
                nextShot = Time.time + 1f / shotRate;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //changed tags here to "bullet" and "rocket" to avoid weird null ref exception error
        //-- my theory is that this was checked the same way the player collision is for the same tag name, hence the error
        if (other.collider.tag == "projectile/bullet" )
        {
            Destroy(other.gameObject);
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);            
        }
        if (other.collider.tag == "projectile/rocket")
        {
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);
            Destroy(other.gameObject);
        }
    }
}
