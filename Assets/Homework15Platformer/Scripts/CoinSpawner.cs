using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(CoinPool))]
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnCoinPoint> _emptySpawnPoints;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private Coin _coinPrefab;
        
        private CoinPool _coinPool;
        private List<SpawnCoinPoint> _filledSpawnPoints;

        private void Awake()
        {
            _coinPool = GetComponent<CoinPool>();
            
            _filledSpawnPoints = new List<SpawnCoinPoint>();

            StartCoroutine(TurnOn());
        }

        private IEnumerator TurnOn()
        {
            WaitForSeconds wait = new WaitForSeconds(_spawnInterval);

            while (true)
            {
                if (_emptySpawnPoints.Count > 0)
                {
                    Coin coin = _coinPool.GetFree();

                    if (coin == null)
                    {
                        Create(_emptySpawnPoints[0]);
                    }
                    else
                    {
                        coin.Activate();
                        coin.Collected += SendToPool;
                    }
                }

                yield return wait;
            }
        }

        private void Create(SpawnCoinPoint spawnPoint)
        {
            Coin coin = Instantiate(_coinPrefab, spawnPoint.transform.position, Quaternion.identity);

            coin.Collected += SendToPool;
            
            _emptySpawnPoints.Remove(spawnPoint);
            _filledSpawnPoints.Add(spawnPoint);
        }

        private void SendToPool(Item item)
        {
            Coin coin = item as Coin;
            
            _coinPool.AddCoin(coin);
            
            coin.Collected -= SendToPool;
        }
    }
}