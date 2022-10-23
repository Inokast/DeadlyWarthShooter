using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform[] arsenalSlot;
    public Weapon[] arsenal;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < arsenal.Length; i++)
        {
            arsenal[i].transform.position = arsenalSlot[i].position;
            arsenal[i].transform.rotation = arsenalSlot[i].rotation;
        }
    }



    private void OnPlayerShoot() 
    {
        foreach (Weapon w in arsenal)
        {
            if (w.unlocked == true) 
            {
                w.ShootWeapon();
            }
            
        }
    }

    public void PickupWeapon(string name) 
    {
        switch (name)
        {
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            OnPlayerShoot();
            //arsenal[0].ShootWeapon();
        }
    }
}
