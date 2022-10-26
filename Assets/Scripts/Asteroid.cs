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
            GameManager.gm.IncrementScore(scoreValue);
        }
        if (other.gameObject.tag == "projectile/rocket")
        {
            TakeDamage(other.gameObject.GetComponent<PlayerBullet>()._bulletpower);
            GameManager.gm.IncrementScore(scoreValue);
        }
    }

    void TakeDamage(float amount)
    {
        asteroidHealthAmt -= amount;

        if (asteroidHealthAmt <= 0)
        {
            Destroy(gameObject);
            GameManager.gm.IncrementScore(scoreValue);
        }
    }
}
