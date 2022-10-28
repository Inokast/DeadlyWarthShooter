using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Daniel Sanchez

public class PlayerStats : MonoBehaviour
{

    //Health playerHealth;
    [SerializeField] private int hp;
    [SerializeField] private int hpMax = 100;
    [SerializeField] public int speed = 3;
    [SerializeField] public float boostPower = 100;
    [SerializeField] public float maxVelocity = 3;

    [SerializeField] private HealthBar hpBar;

    //adding HP property for public access (in PlayerCollision) + data protection purposes- T.E.
    public int HP
    {
        get { return hp; }
        set 
        { 
            hp = value;

            if(hp <= 0) { hp = 0; }
            if(hp > hpMax) { hpMax = hp; }
        }
    }

    void Start()
    {
        hpBar.SetMaxHealth(hpMax);

    }

    public void TakeDamage(int amount) 
    {
        HP = HP - amount;
        HP = Mathf.Clamp(HP, 0, hpMax);
        CheckHealth();
        hpBar.SetHealth(hp);
    }

    public void RecoverHealth(int amount) 
    {
        HP = HP + amount;
        HP = Mathf.Clamp(HP, 0, hpMax);
        hpBar.SetHealth(HP);
    }

    private void CheckHealth() 
    {
        if (HP <= 0) 
        {
            PlayerDeath();
        }
    }

    private void Respawn() 
    {
        RecoverHealth(hpMax);
    }

    private void PlayerDeath() 
    {
        if (GameManager.gm.Lives > 0)
        {
            GameManager.gm.DecrementLives();
            Respawn();
        }

        else 
        {
            GameManager.gm.GameOver();
        }
        print("The player has died");
    }

}
