using System;
using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(EnemyMover))]
    public class EnemyVisual : MonoBehaviour
    {
        private Animator _animator;
        private EnemyMover _mover;
        private float _reverseRotation = 180f;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _mover = GetComponent<EnemyMover>();
        }

        private void OnEnable()
        {
            _mover.DirectionChanged += FlipSprite;
            _mover.DirectionChanged += ChangeAnimation;
        }

        private void OnDisable()
        {
            _mover.DirectionChanged -= FlipSprite;
            _mover.DirectionChanged -= ChangeAnimation;
        }
        
        private void ChangeAnimation(Vector2 vector2D)
        {
            _animator.SetFloat("Speed", Math.Abs(vector2D.x));
        }

        private void FlipSprite(Vector2 vector2D)
        {
            transform.Rotate(new Vector3(0f, _reverseRotation, 0f));
        }
    }
}