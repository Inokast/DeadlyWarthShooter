using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int hpMax;
    [SerializeField] private int speed;
    // Start is called before the first frame update
   
    public void TakeDamage(int amount) 
    {
        hp = hp - amount;

    }

    private void CheckHealth() 
    {
        if (hp <= 0) 
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath() 
    {
        //We'll talk about this
        print("The player has died");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
