using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerStats player;

    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy") 
        {
            print("Collided with Enemy");
            player.TakeDamage(1);
        }

        if (other.collider.tag == "EnemyBulletType1")
        {
            print("Collided with Enemy");
        }

        if (other.collider.tag == "Asteroid") 
        {
            print("Collided with Asteroid");
        }
    }
}
