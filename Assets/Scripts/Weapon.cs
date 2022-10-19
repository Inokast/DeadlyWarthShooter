using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public Sprite sprite;
    public int fireRate;
    public int weaponSpeed;
    public GameObject bulletPrefab;

    public virtual void ShootWeapon() 
    {
        Instantiate(bulletPrefab);
    }
}
