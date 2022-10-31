using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting, (Daniel Sanchez, Steven Thompson)

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
    [SerializeField] private HealthBar hpBar;

    [Header("Shooting Values")]
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject[] cannon;
    [SerializeField] float shotRate;
    float nextShot;
    public Transform thisObject;
    public AudioClip shootSFX;
    public AudioClip deathSFX;
    public AudioClip bossShootSFX;
    public AudioClip bossDeathSFX;
    AudioSource sfxAudio;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        nextShot = Time.time;
        thisObject.parent = null;
        manager = EnemyManager.FindObjectOfType<EnemyManager>();
        sfxAudio = gameObject.GetComponent<AudioSource>();
        hpBar.SetMaxHealth(((int)eHealthAmt));

    }

    void FixedUpdate()
    {
        if(player != null)
        {
            ChasePlayer();
        }
    }

    void Update()
    {
        if(player != null && player.activeInHierarchy)
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= shootingRange)
            {
                ShootProjectile();
            }
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
            //Debug.Log("Enemy is engaging player");
        }
    }

    private void TakeDamage(float amount) 
    {
        eHealthAmt -= amount;
        hpBar.SetHealth(((int)eHealthAmt));

        if (eHealthAmt <= 0)
        {
            if (this.gameObject.CompareTag("Boss"))
            {
                manager.bossAlive = false;
                GameManager.gm.IncrementScore(scoreValue);
                manager.EnemyChecker();
                Debug.Log("Boss is dead");
                sfxAudio.clip = bossDeathSFX;
                sfxAudio.Play();
                Destroy(gameObject);
                

            }
            else    
            GameManager.gm.IncrementScore(scoreValue);
            manager.numEnemies--;
            manager.EnemyChecker();
            sfxAudio.clip = deathSFX;
            sfxAudio.Play();
            // Debug.Log("enemy" + gameObject.name + "is dead");
            Destroy(gameObject);
            
            
        }
    }

    void ShootProjectile()
    {
        if (Time.time > nextShot)
        {
            foreach(GameObject c in cannon)
            {
                GameObject boltClone;
                boltClone = Instantiate(projectile, c.transform.position, Quaternion.identity);
                nextShot = Time.time + 1f / shotRate;
                if (this.gameObject.CompareTag("Boss"))
                {
                    sfxAudio.clip = bossShootSFX;
                    sfxAudio.Play();
                }
                else
                    sfxAudio.clip = shootSFX;
                sfxAudio.Play();

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //changed tags here to "bullet" and "rocket" to avoid weird null ref exception error
        //-- my theory is that this was checked the same way the player collision is for the same tag name, hence the error- T.E.
        if (other.gameObject.tag == "projectile/bullet" )
        {
            Destroy(other.gameObject);
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);            
        }
        if (other.gameObject.tag == "projectile/rocket")
        {
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);
            Destroy(other.gameObject);
        }

        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "projectile/bomb")
        {
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);
        }
    }

}
