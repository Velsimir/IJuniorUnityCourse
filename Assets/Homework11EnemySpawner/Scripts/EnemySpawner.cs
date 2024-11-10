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
            float angle = Random.Range(0f, 360f);
            float radians = angle * Mathf.Deg2Rad;

            return new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians));
        }
    }
}