using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework11
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private float _enemySpeed;

        public void Spawn()
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform);
            enemy.Initilazie(GetRandomVectorDirectionNormalize(), _enemySpeed);
        }

        private Vector3 GetRandomVectorDirectionNormalize()
        {
            float maxAngle = 360f;
            float minAngle = -360f;
            
            return new Vector3(Random.Range(minAngle, maxAngle), 0, Random.Range(minAngle, maxAngle)).normalized;
        }
    }
}