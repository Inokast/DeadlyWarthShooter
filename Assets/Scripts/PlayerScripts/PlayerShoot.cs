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
        AssignSlots();
    }

    public void AssignSlots() 
    {
        if (gameObject.activeInHierarchy)
        {
            for (int i = 0; i < arsenal.Length; i++)
            {
                arsenal[i].transform.position = arsenalSlot[i].position;
                arsenal[i].transform.rotation = arsenalSlot[i].rotation;
            }
        }

        
    }

    private void OnPlayerShoot() 
    {
        if (gameObject.activeInHierarchy) 
        {
            foreach (Weapon w in arsenal)
            {
                w.ShootWeapon();
            }
        }
            
    }

    private void SwitchSlots() 
    {
        if (gameObject.activeInHierarchy) 
        {
            Weapon[] temp = { arsenal[1], arsenal[2], arsenal[3], arsenal[0] };
            arsenal = temp;

            AssignSlots();
        }

      
    }

    

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy) 
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
}
