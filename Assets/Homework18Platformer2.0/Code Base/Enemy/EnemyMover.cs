using System;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Characteristic))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Transform _targetAt;
        [SerializeField] private Transform _targetTo;
        [SerializeField] private EnemyAggression _aggression;

        private Transform _currentTarget;
        private Transform _nextTarget;
        private Transform _tempTarget;
        private Characteristic _characteristic;
        private Rigidbody2D _rigidbody2D;
        private float _minDistanceToTarget = 0.2f;
        private Vector2 _direction;

        public Action<Vector2> DirectionChanged;

        private void Awake()
        {
            _characteristic = GetComponent<Characteristic>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _currentTarget = _targetTo;
            _nextTarget = _targetAt;
        }

        private void OnEnable()
        {
            _aggression.PlayerIn += FollowPlayer;
            _aggression.PlayerOut += BackOnPatrol;
        }

        private void FixedUpdate()
        {
            Patrol();
            ChangeTarget();
        }
        
        private void OnDisable()
        {
            _aggression.PlayerIn -= FollowPlayer;
            _aggression.PlayerOut -= BackOnPatrol;
        }

        private void Patrol()
        {
            _direction = (_currentTarget.position - transform.position).normalized;
            
            _rigidbody2D.AddForce(_direction * _characteristic.Speed);
            _rigidbody2D.linearVelocity = Vector2.ClampMagnitude(_rigidbody2D.linearVelocity, _characteristic.Speed);
        }

        private void ChangeTarget()
        {
            if (transform.position.IsEnoughDistance(_currentTarget.position, _minDistanceToTarget))
            {
                (_currentTarget, _nextTarget) = (_nextTarget, _currentTarget);
                DirectionChanged?.Invoke((_currentTarget.position - transform.position).normalized);
            }
        }
        
        private void FollowPlayer(Player player)
        {
            _tempTarget = _currentTarget;
            _currentTarget = player.transform;
        }
        
        private void BackOnPatrol()
        {
            _currentTarget = _tempTarget;
        }
    }
}
