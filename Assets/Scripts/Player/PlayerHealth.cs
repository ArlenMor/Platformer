using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Health _health;

    [SerializeField, Range(1, 3)] private int _maxHealth;

    private void Awake()
    {
        _health = new Health(_maxHealth);

        Debug.Log("HP = " + _health);

        _health.EventDie += OnDie;
    }

    public void ReduceHealth()
    {
        _health.ReduceHealth();
        Debug.Log("-1 HP!");
    }

    public void IncreaseHealth()
    {
        _health.IncreaseHealth();
        Debug.Log("+1 HP!");
    }

    private void OnDie()
    {
        gameObject.SetActive(false);
        Debug.Log("Dead!!!");
    }
}
