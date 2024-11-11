using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework12
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Target[] _spawnTargets;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private float _enemySpeed;

        public void Spawn()
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform);
            enemy.Initilazie(GetRandomTarget(), _enemySpeed);
        }

        private Target GetRandomTarget()
        {
            return _spawnTargets[Random.Range(0, _spawnTargets.Length)];
        }
    }
}