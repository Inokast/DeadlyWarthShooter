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
}
