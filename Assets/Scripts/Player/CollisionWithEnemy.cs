using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class CollisionWithEnemy : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private static string EnemyLayer = nameof(EnemyLayer);
    private LayerMask _enemyLayerMask;
    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _enemyLayerMask = LayerMask.GetMask(EnemyLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;

        if ((1 << layer) == _enemyLayerMask)
        {
            _playerHealth.ReduceHealth();
        }
    }
}
