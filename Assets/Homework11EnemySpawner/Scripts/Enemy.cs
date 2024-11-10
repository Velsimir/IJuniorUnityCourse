using System;
using UnityEngine;

namespace Homework11
{
    [RequireComponent(typeof(EnemyMover))]
    public class Enemy : MonoBehaviour
    {
        private float _speed;
        private EnemyMover _enemyMover;
        private Vector3 _moveDirection;

        private void Awake()
        {
            _enemyMover = GetComponent<EnemyMover>();
        }

        private void Start()
        {
            _enemyMover.Initilazie(_speed, _moveDirection);
        }

        public void Initilazie(Vector3 direction, float speed)
        {
            _moveDirection = direction;
            _speed = speed;
        }
    }
}