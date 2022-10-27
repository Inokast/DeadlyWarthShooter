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
    [SerializeField] GameObject healthPickUp;
    float offset = .1f;
    [SerializeField] float deathTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xSpeed = Random.Range(-7, 7);
        ySpeed = Random.Range(-7, 7);

        Destroy(gameObject, deathTime);
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(xSpeed, ySpeed);
        }
        AsteroidBoundsCheck();
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

    void AsteroidBoundsCheck()
    {
        float[] bounds = {-36, 36, 36, -36 };

        if (gameObject.transform.position.x < bounds[0])    //left bound
        {
            float newXPos = gameObject.transform.position.x * -1 - offset;
            gameObject.transform.position = new Vector2(newXPos, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.x > bounds[1])    //right bound
        {
            float newXPos = gameObject.transform.position.x * -1 + offset;
            gameObject.transform.position = new Vector2(newXPos, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.y > bounds[2])    //top bound
        {
            float newYPos = gameObject.transform.position.y * -1 + offset;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, newYPos);
        }

        if (gameObject.transform.position.y < bounds[3])    //bottom bound
        {
            float newYPos = gameObject.transform.position.y * -1 - offset;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, newYPos);
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
        int chance = Random.Range(1, 4);

        if(chance == 1)
        {
            Instantiate(healthPickUp, gameObject.transform.position, Quaternion.identity);    //--for spawning a health pickup
                                                                                              //where the asteroid was destroyed- T.E.
        }
    }
}
