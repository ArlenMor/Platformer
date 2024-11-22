using System;
using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    public event Action WasCollected;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement playerMovement;
        collision.TryGetComponent<PlayerMovement>(out playerMovement);

        if (playerMovement != null)
        {
            WasCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}