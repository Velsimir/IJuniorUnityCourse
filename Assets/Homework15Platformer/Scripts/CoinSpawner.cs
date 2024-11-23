using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(CoinPool))]
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private List<SpwanPoint> _spawnPoints;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private Coin _coinPrefab;
        
        private CoinPool _coinPool;

        private void Awake()
        {
            _coinPool = GetComponent<CoinPool>();
            FillSpawnPoints();

            StartCoroutine(TurnOn());
        }

        private void Activate()
        {
            Coin coin = _coinPool.GetFree();
            coin.Activate();
            coin.Collected += Deactivate;
        }

        private void Deactivate(Coin coin)
        {
            _coinPool.AddCoin(coin);
            coin.Collected -= Deactivate;
        }

        private IEnumerator TurnOn()
        {
            WaitForSeconds wait = new WaitForSeconds(_spawnInterval);

            while (true)
            {
                if (_coinPool.HasFreeCoins)
                    Activate();
                
                yield return wait;
            }
        }

        private void FillSpawnPoints()
        {
            foreach (var point in _spawnPoints)
            {
                Coin coin = Instantiate(_coinPrefab, point.transform.position, Quaternion.identity);
                coin.Collected += Deactivate;
            }
        }
    }
}