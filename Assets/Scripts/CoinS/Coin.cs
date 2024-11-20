using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action WasColelcted;

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement playerMovement;
        collision.TryGetComponent<PlayerMovement>(out playerMovement);

        if (playerMovement != null)
        {
            WasColelcted?.Invoke();
            Destroy(gameObject);
        }
    }*/

    public void Collected()
    {
        WasColelcted?.Invoke();
        Destroy(gameObject);
    }
}
