using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Camera cam;

    [SerializeField] private float maxVelocity = 3;
    //[SerializeField] private float rotationSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    }

    private void RotatePlayer() 
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
    }

    private void ClampVelocity() 
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void MoveForward(float amount) 
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);
    }

    private void MoveSideways(float amount) 
    {
        Vector2 force = transform.right * amount;

        rb.AddForce(force);
    }
}
