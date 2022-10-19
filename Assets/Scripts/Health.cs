//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting

public class Health
{
    int health;

    public int _Health
    {
        get { return health; }
        set 
        { 
            health = value;
            if (health < 0) { health = 0; }
        }
    }

    public void DamageHealth(int amt)
    {
        _Health -= amt;
    }

    public void IncreaseHealth(int amt)
    {
        _Health += amt;
    }
}
