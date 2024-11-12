using UnityEngine;

namespace Homework12
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Target _spawnTarget;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private float _enemySpeed;

        public void Spawn()
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform);
            enemy.Initilazie(_spawnTarget, _enemySpeed);
        }
    }
}