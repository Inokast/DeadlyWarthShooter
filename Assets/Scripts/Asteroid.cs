using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting

public class Asteroid : MonoBehaviour
{
    [Header("Asteroid Values")]
    Rigidbody2D rb;
    [SerializeField] float xSpeed, ySpeed;
    [SerializeField] int scoreValue;
    [SerializeField] float asteroidHealthAmt;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xSpeed = Random.Range(-7, 7);
        ySpeed = Random.Range(-7, 7);
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(xSpeed, ySpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "projectile/bullet")
        {
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);
            Destroy(other.gameObject);
            GameManager.gm.IncrementScore(scoreValue);
        }
        if (other.gameObject.tag == "projectile/rocket")
        {
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);
            Destroy(other.gameObject);
            GameManager.gm.IncrementScore(scoreValue);
        }
    }

    void TakeDamage(float amount)
    {
        asteroidHealthAmt -= amount;

        if (asteroidHealthAmt <= 0)
        {
            SpawnHealthObj();
            Destroy(gameObject);
            GameManager.gm.IncrementScore(scoreValue);
        }
    }

    void SpawnHealthObj()
    {
        int chance = Random.Range(1, 6);

        if(chance == 1)
        {
            //Instantiate();    --for spawning a health thingy where the asteroid was destroyed- T.E.
        }
    }
}
