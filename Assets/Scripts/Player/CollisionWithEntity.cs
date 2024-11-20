using System;
using UnityEngine;

public class CollisionWithEntity : MonoBehaviour
{
    public event Action<Coin> EventCoinCollision;
    public event Action<MedicalKit> EventMedicalKitCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag.ToLower();

        if (tag == TagsCheck.Coin)
        {
            Coin coin = collision.gameObject.GetComponent<Coin>();

            if (coin != null)
            {
                Debug.Log("Найден компонент Coin");

                if (EventCoinCollision != null)
                {
                    EventCoinCollision.Invoke(coin);
                }
                else
                {
                    Debug.LogWarning("Нет подписчиков на событие EventCoinCollision.");
                }
            }
            else
            {
                Debug.LogError("Компонент Coin не найден!");
            }
        }
        else if (tag == TagsCheck.MedicalKit)
        {
            MedicalKit medicalKit = collision.GetComponent<MedicalKit>();

            EventMedicalKitCollision?.Invoke(medicalKit);
        }
    }
}