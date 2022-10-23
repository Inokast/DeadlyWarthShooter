using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] private float bulletPower = 20;
    [SerializeField] private int bulletLifetime = 1;

    private void Start()
    {
        StartCoroutine(BulletLife());
    }

    public float _bulletpower 
    {
        get { return bulletPower; } 
    }

    private IEnumerator BulletLife() 
    {
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(gameObject);
    }
}
