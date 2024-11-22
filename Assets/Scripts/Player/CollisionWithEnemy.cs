using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class CollisionWithEnemy : MonoBehaviour
{
    public event Action<PlayerMovement> OnCollisionWithEnemy; 
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag.ToLower();

        if (tag == TagsCheck.Patroller.ToLower())
        {
            EnemyPatroller patroller = collision.gameObject.GetComponent<EnemyPatroller>();

            patroller.CollisionWithPlayer();
            _playerHealth.ReduceHealth();
            Debug.LogWarning("Столкновение с врагом. -1 HP.");

            OnCollisionWithEnemy?.Invoke(GetComponent<PlayerMovement>());
        }
    }
}
