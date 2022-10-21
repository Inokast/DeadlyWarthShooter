//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting

public class Health
{
    float health;

    public float _Health
    {
        get { return health; }
        set 
        { 
            health = value;
            if (health < 0) { health = 0; }
        }
    }

    public void DamageHealth(float amt)
    {
        _Health -= amt;
    }

    public void IncreaseHealth(float amt)
    {
        _Health += amt;
    }
}
