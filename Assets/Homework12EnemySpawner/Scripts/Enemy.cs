using System;
using UnityEngine;

namespace Homework12
{
    [RequireComponent(typeof(EnemyMover))]
    public class Enemy : MonoBehaviour
    {
        private float _speed;
        private EnemyMover _mover;
        private Target _target;

        private void Awake()
        {
            _mover = GetComponent<EnemyMover>();
        }

        private void Update()
        {
            _mover.PurseTarget(_speed, _target);
            transform.LookAt(_target.transform.position);
        }

        public void Initilazie(Target target, float speed)
        {
            _speed = speed;
            _target = target;
        }
    }
}