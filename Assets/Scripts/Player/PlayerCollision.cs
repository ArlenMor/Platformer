using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private CollisionWithEnemy _collisionWithEnemy;
    private CollisionWithEntity _collisionWithEntity;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _collisionWithEnemy = GetComponent<CollisionWithEnemy>();
        _collisionWithEntity = GetComponent<CollisionWithEntity>();
        _playerHealth = GetComponent<PlayerHealth>();

        _collisionWithEnemy.EventEnemyPatrollerCollision += OnCollisionWithEnemyPatroller;

        _collisionWithEntity.EventCoinCollision += OnCollisionWithCoin;
        _collisionWithEntity.EventMedicalKitCollision += OnCollisionWithMedicalKit;
    }

    private void OnCollisionWithEnemyPatroller(EnemyPatroller patroller)
    {
        patroller.CollisionWithPlayer();

        _playerHealth.ReduceHealth();

        Debug.Log("Столкнулся с врагом. -1HP");
    }

    private void OnCollisionWithCoin(Coin coin)
    {
        coin.Collected();
        Debug.Log("Собрал монету");
    }

    private void OnCollisionWithMedicalKit(MedicalKit medicalKit)
    {
        medicalKit.Collected();
        _playerHealth.IncreaseHealth();
        Debug.Log("Собрал аптечку. +1 HP");
    }
}