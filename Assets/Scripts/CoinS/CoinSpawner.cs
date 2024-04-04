using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField, Range(0, 2)] private float _spawnDeley = .5f;

    private CoinSpawnPoint[] _spawnPoints;
    private WaitForSeconds _deley;

    private void Awake()
    {
        _deley = new WaitForSeconds(_spawnDeley);

        _spawnPoints = new CoinSpawnPoint[transform.childCount];

        for(int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = transform.GetChild(i).GetComponent<CoinSpawnPoint>();

        StartCoroutine(nameof(SpawnCoins));
    }

    private IEnumerator SpawnCoins()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i].Spawn();

            yield return _deley;
        }
    }
}
