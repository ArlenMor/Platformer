using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Health _health;

    [SerializeField, Range(1, 3)] private int _maxHealth;

    private void Awake()
    {
        _health = new Health(_maxHealth);

        _health.EventDie += OnDie;
    }

    public void ReduceHealth()
    {
        _health.ReduceHealth();
    }

    public void IncreaseHealth()
    {
        _health.IncreaseHealth();
    }

    private void OnDie()
    {
        gameObject.SetActive(false);
    }
}
