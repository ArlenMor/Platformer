using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    public void Spawn()
    {
        Instantiate(_coinPrefab, transform);
    }
}