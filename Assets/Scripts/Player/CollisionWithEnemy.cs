using System;
using UnityEngine;

public class CollisionWithEnemy : MonoBehaviour
{
    public event Action<EnemyPatroller> EventEnemyPatrollerCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag.ToLower();

        if (tag == TagsCheck.Patroller)
        {
            EnemyPatroller patroller = collision.gameObject.GetComponent<EnemyPatroller>();

            EventEnemyPatrollerCollision?.Invoke(patroller);
        }
    }
}
