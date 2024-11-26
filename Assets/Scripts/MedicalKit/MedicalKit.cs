using System;
using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    public event Action WasCollected;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth;
        collision.TryGetComponent<PlayerHealth>(out playerHealth);

        if (playerHealth != null)
        {
            WasCollected?.Invoke();
            Destroy(gameObject);

            playerHealth.IncreaseHealth();
        }
    }
}