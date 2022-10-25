using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Daniel Sanchez

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerStats player;

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        //changed tag names and damage method for testing- T.E.
        if (other.collider.tag == "projectile/missile") 
        {
            print("Collided with Enemy projectile");
            player.TakeDamage(other.gameObject.GetComponent<EnemyProjectile>().damageAmt);
            Destroy(other.gameObject);
        }

        if (other.collider.tag == "projectile/bolt")
        {
            print("Collided with Enemy projectile");
            player.TakeDamage(other.gameObject.GetComponent<EnemyProjectile>().damageAmt);
            Destroy(other.gameObject);
        }

        if (other.collider.tag == "Asteroid") 
        {
            print("Collided with Asteroid");
            player.TakeDamage(player.HP / 2);
            Destroy(other.gameObject);
        }

        if(other.collider.tag == "enemy/kamikaze")
        {
            player.TakeDamage(player.HP / 2);
            Destroy(other.gameObject);
            print("Collided with kamikaze Enemy");
        }
    }
}
