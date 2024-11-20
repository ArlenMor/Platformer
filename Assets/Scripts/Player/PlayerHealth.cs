using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event System.Action EventDie;

    [SerializeField, Range(1, 3)] private int _maxHealth;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void ReduceHealth()
    {
        _currentHealth--;

        if(_currentHealth <= 0)
            Die();
    }

    public void IncreaseHealth()
    {
        _currentHealth++;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
