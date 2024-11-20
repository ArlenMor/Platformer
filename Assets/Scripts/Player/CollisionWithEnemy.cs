using System;
using UnityEngine;

public class CollisionWithEnemy : MonoBehaviour
{
    public event Action<EnemyPatroller> EventEnemyPatrollerCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag.ToLower();

        if (tag == TagsCheck.Patroller)
        {
            EnemyPatroller patroller = collision.gameObject.GetComponent<EnemyPatroller>();

            EventEnemyPatrollerCollision?.Invoke(patroller);
        }
    }
}
