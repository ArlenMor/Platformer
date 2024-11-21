using System;
using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    public event Action WasColelcted;

    public void Collected()
    {
        WasColelcted?.Invoke();
        Destroy(gameObject);
    }
}