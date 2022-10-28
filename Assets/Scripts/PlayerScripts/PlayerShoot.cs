using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Daniel Sanchez

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

    private void SwitchSlots() 
    {

        Weapon[] temp = { arsenal[1], arsenal[2], arsenal[3], arsenal[0] };
        arsenal = temp;

        for (int i = 0; i < arsenal.Length; i++)
        {
            arsenal[i].transform.position = arsenalSlot[i].position;
            arsenal[i].transform.rotation = arsenalSlot[i].rotation;
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
        }

        if (Input.GetKeyDown("x"))
        {
            SwitchSlots();
        }
    }
}
