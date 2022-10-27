using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Daniel Sanchez

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerStats player;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        //changed tag names and damage method for testing- T.E.
        if (other.gameObject.tag == "projectile/missile") 
        {
            //print("Collided with Enemy projectile");
            player.TakeDamage(other.gameObject.GetComponent<EnemyProjectile>().damageAmt);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "projectile/bolt")
        {
            //print("Collided with Enemy projectile");
            player.TakeDamage(other.gameObject.GetComponent<EnemyProjectile>().damageAmt);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Asteroid") 
        {
            //print("Collided with Asteroid");
            player.TakeDamage(player.HP / 2);
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "enemy/kamikaze")
        {
            player.TakeDamage(player.HP / 2);
            Destroy(other.gameObject);
            //print("Collided with kamikaze Enemy");
        }

        //for collecting health objects? -T.E.
        if (other.gameObject.CompareTag("Health"))
        {
            player.RecoverHealth(10);
            Destroy(other.gameObject);
            Debug.Log("Collected health");
        }
    }
}
