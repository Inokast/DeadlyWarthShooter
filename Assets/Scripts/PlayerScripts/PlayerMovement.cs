using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Daniel Sanchez

public class PlayerMovement : MonoBehaviour
{
    private PlayerStats player;
    private Rigidbody2D rb;
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yAxis = Input.GetAxisRaw("Vertical");
        float xAxis = Input.GetAxisRaw("Horizontal");

        MoveForward(yAxis);
        MoveSideways(xAxis);
        RotatePlayer();

        ClampVelocity();

        if (Input.GetKey(KeyCode.Space)) 
        {
            Boost();
        }
    }

    private void RotatePlayer() 
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
    }

    private void ClampVelocity() 
    {
        float x = Mathf.Clamp(rb.velocity.x, -player.maxVelocity, player.maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -player.maxVelocity, player.maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void MoveForward(float amount) 
    {
        Vector2 force = Vector2.up * amount * player.speed;

        rb.AddForce(force);
    }

    private void MoveSideways(float amount) 
    {
        Vector2 force = Vector2.right * amount * player.speed;

        rb.AddForce(force);
    }

    private void Boost()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        Vector2 force = direction * player.speed * player.boostPower;

        rb.AddForce(force);
    }
}
