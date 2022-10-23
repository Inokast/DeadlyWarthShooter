using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public int fireRate = 100;
    public float bulletSpeed = 3;
    float nextShot;
    public GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    public bool unlocked = false;

    public virtual void ShootWeapon() 
    {
        if (Time.time > nextShot) 
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            print("Bullet is made");

            Vector2 force = firePoint.up * bulletSpeed * 10;

            rb.AddForce(force, ForceMode2D.Impulse);

            nextShot = Time.time + 1f / fireRate;
        }
    }
}
