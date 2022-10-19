using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Weapon[] arsenal;

    // Start is called before the first frame update
    private void OnPlayerShoot() 
    {
        foreach (Weapon w in arsenal)
        {
            w.ShootWeapon();
        }
    }

    public void PickupWeapon(string name) 
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) 
        {
            OnPlayerShoot();
        }
    }
}
