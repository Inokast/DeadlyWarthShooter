using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    //Health playerHealth;
    [SerializeField] private int hp;
    [SerializeField] private int hpMax = 100;
    [SerializeField] public int speed = 3;
    [SerializeField] public float boostPower = 100;
    [SerializeField] public float maxVelocity = 3;

    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = new Health();
        //playerHealth._Health = hp;
        //playerHealth._healthMax = hpMax;
    }

    public void TakeDamage(int amount) 
    {
        hp = hp - amount;
        hp = Mathf.Clamp(hp, 0, hpMax);
        CheckHealth();
    }

    public void RecoverHealth(int amount) 
    {
        hp = hp + amount;
        hp = Mathf.Clamp(hp, 0, hpMax);
    }

    private void CheckHealth() 
    {
        if (hp <= 0) 
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
