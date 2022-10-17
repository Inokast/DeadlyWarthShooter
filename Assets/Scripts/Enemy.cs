using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    [SerializeField] float enemySpeed;
    [SerializeField] float disToPlayer = 1f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        ChasePlayer();
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
}
