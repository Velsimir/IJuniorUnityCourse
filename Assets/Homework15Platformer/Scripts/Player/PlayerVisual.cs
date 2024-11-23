using System;
using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerVisual : MonoBehaviour
    {
        private const string AnimatorParameterSpeed = "Speed";
        
        private Animator _animator;
        private PlayerInputHandler _inputHandler;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _inputHandler = GetComponent<PlayerInputHandler>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _inputHandler.MoveButtonPressed += ChangeAnimation;
        }
        
        private void OnDisable()
        {
            _inputHandler.MoveButtonPressed -= ChangeAnimation;
        }

        private void ChangeAnimation(Vector2 vector2D)
        {
            if (vector2D.x > 0)
                _spriteRenderer.flipX = false;
            else if (vector2D.x < 0)
                _spriteRenderer.flipX = true;

            _animator.SetFloat(AnimatorParameterSpeed, Math.Abs(vector2D.x));
        }
    }
}