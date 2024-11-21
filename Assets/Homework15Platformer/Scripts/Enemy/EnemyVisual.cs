using System;
using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(EnemyMover))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyVisual : MonoBehaviour
    {
        private Animator _animator;
        private EnemyMover _mover;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _mover = GetComponent<EnemyMover>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
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
            _spriteRenderer.flipX = vector2D.x < 0;
        }
    }
}