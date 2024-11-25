using System;
using UnityEngine;

namespace Homework15
{
    public class EnemyVisual : MonoBehaviour
    {
        private const string AnimationParameterSpeed = "Speed";
        
        private Animator _animator;
        private EnemyMover _mover;
        private Quaternion _rotationLeft = Quaternion.Euler(0, 180, 0);
        private Quaternion _rotationRight = Quaternion.Euler(0, 0, 0);

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
            _animator.SetFloat(AnimationParameterSpeed, Math.Abs(vector2D.x));
        }

        private void FlipSprite(Vector2 vector2D)
        {
            if (vector2D.x < 0)
                transform.rotation = _rotationLeft;
            else if(vector2D.x > 0)
                transform.rotation = _rotationRight;
        }
    }
}