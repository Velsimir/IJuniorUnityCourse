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
            enemy.Initilazie(GetRandomVectorDirection(), _enemySpeed);
        }

        private Vector3 GetRandomVectorDirection()
        {
            float maxAngle = 360f;
            float minAngle = 0f;
            
            return new Vector3(0, Random.Range(minAngle, maxAngle), 0);
        }
    }
}