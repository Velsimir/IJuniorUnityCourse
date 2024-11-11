using System;
using UnityEngine;

namespace Homework11
{
    [RequireComponent(typeof(EnemyMover))]
    public class Enemy : MonoBehaviour
    {
        private float _speed;
        private EnemyMover _mover;

        private void Awake()
        {
            _mover = GetComponent<EnemyMover>();
        }

        private void Start()
        {
            _mover.StartMove(_speed);
        }

        public void Initilazie(Vector3 direction, float speed)
        {
            _speed = speed;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}