public class Health
{
    public event System.Action EventDie;
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public Health(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void ReduceHealth(int value = 1)
    {
        CurrentHealth -= value;

        if (CurrentHealth <= 0)
            Die();
    }

    public void IncreaseHealth(int value = 1)
    {
        CurrentHealth += value;
    }

    private void Die()
    {
        EventDie?.Invoke();
    }
}
