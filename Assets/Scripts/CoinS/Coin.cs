using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action WasColelcted;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Player>() != null)
        {
            Debug.Log("here");
            WasColelcted?.Invoke();
            Destroy(gameObject);
        }
    }
}
