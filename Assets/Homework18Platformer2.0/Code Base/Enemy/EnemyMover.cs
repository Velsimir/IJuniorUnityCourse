using System;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Transform _targetAt;
        [SerializeField] private Transform _targetTo;
        [SerializeField] private EnemyAggression _aggression;
        [SerializeField] private CharacteristicSo _characteristic;

        private Transform _currentTarget;
        private Transform _nextTarget;
        private Transform _tempTarget;
        private Rigidbody2D _rigidbody2D;
        private float _minDistanceToTarget = 0.2f;
        private Vector2 _direction;

        public Action<Vector2> DirectionChanged;

        private void Awake()
        {
            _characteristic = GetComponent<ICharacteristic>().CharacteristicSo;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _currentTarget = _targetTo;
            _nextTarget = _targetAt;
        }

        private void OnEnable()
        {
            _aggression.TargetIn += SwitchTarget;
            _aggression.TargetOut += BackOnPatrol;
        }

        private void FixedUpdate()
        {
            Patrol();
            TryChangePatrolTarget();
        }
        
        private void OnDisable()
        {
            _aggression.TargetIn -= SwitchTarget;
            _aggression.TargetOut -= BackOnPatrol;
        }

        private void Patrol()
        {
            _direction = (_currentTarget.position - transform.position).normalized;
            
            _rigidbody2D.AddForce(_direction * _characteristic.Speed);
            _rigidbody2D.linearVelocity = Vector2.ClampMagnitude(_rigidbody2D.linearVelocity, _characteristic.Speed);
        }

        private void TryChangePatrolTarget()
        {
            if (transform.position.IsEnoughDistance(_currentTarget.position, _minDistanceToTarget))
            {
                (_currentTarget, _nextTarget) = (_nextTarget, _currentTarget);
                DirectionChanged?.Invoke((_currentTarget.position - transform.position).normalized);
            }
        }
        
        private void SwitchTarget(ITarget target)
        {
            _tempTarget = _currentTarget;
            _currentTarget = target.Transform;
        }
        
        private void BackOnPatrol()
        {
            _currentTarget = _tempTarget;
        }
    }
}
