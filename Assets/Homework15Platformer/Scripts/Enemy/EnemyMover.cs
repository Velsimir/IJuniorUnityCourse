using System;
using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(EnemyCharacteristic))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Transform _targetAt;
        [SerializeField] private Transform _targetTo;

        private Transform _currentTarget;
        private Transform _nextTarget;
        private EnemyCharacteristic _enemyCharacteristic;
        private float _minDistanceToTarget = 0.2f;

        public Action<Vector2> DirectionChanged;

        private void Awake()
        {
            _enemyCharacteristic = GetComponent<EnemyCharacteristic>();
            _currentTarget = _targetTo;
            _nextTarget = _targetAt;
        }

        private void Update()
        {
            Patrol();
            ChangeTarget();
        }

        private void Patrol()
        {
            transform.position = Vector3
                .MoveTowards(transform.position, _currentTarget.position, _enemyCharacteristic.Speed * Time.deltaTime);
        }

        private void ChangeTarget()
        {
            if (transform.position.IsEnoughDistance(_currentTarget.position, _minDistanceToTarget))
            {
                (_currentTarget, _nextTarget) = (_nextTarget, _currentTarget);
                DirectionChanged?.Invoke((_currentTarget.position - transform.position).normalized);
            }
        }
    }
}