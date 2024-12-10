using System;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerVisual : MonoBehaviour
    {
        private const string AnimatorParameterSpeed = "Speed";
        
        private Animator _animator;
        private PlayerInputHandler _inputHandler;
        private Quaternion _rotationLeft = Quaternion.Euler(0, 180, 0);
        private Quaternion _rotationRight = Quaternion.Euler(0, 0, 0);

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _inputHandler = GetComponent<PlayerInputHandler>();
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
                transform.rotation = _rotationRight;
            else if (vector2D.x < 0)
                transform.rotation = _rotationLeft;
            
            _animator.SetFloat(AnimatorParameterSpeed, Math.Abs(vector2D.x));
        }
    }
}