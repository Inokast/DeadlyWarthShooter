//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting
using UnityEngine;
public class Health
{
    float health;
    float healthMax;

    public float _Health
    {
        get { return health; }
        set 
        { 
            health = value;
            if (health < 0) { health = 0; }

        }
    }

    public float _healthMax
    {
        get { return healthMax; }
        set
        {
            healthMax = value;
            if (healthMax < 0) { healthMax = 0; }

        }
    }

    public void DamageHealth(float amt)
    {
        _Health -= amt;
        health = Mathf.Clamp(health, 0, healthMax);
    }

    public void IncreaseHealth(float amt)
    {
        _Health += amt;
        health = Mathf.Clamp(health, 0, healthMax);
    }

    public bool isDead() 
    {
        if (health <= 0)
        {
            return true;
        }

        else 
        {
            return false;
        }
        
    }
}
