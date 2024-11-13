using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework12
{
    public class SpawnHandler : MonoBehaviour
    {
        [SerializeField] private List<EnemySpawner> _enemySpawners;
        [SerializeField] private float _delayBetweenSpawns;

        private void Awake()
        {
            StartCoroutine(SpawnWithDelay());
        }

        private EnemySpawner GetRandomSpawner()
        {
            int amountSpawners = _enemySpawners.Count;

            return _enemySpawners[Random.Range(0, amountSpawners)];
        }

        private IEnumerator SpawnWithDelay()
        {
            WaitForSeconds wait = new WaitForSeconds(_delayBetweenSpawns);

            while (true)
            {
                GetRandomSpawner().Spawn();

                yield return wait;
            }
        }
    }
}
