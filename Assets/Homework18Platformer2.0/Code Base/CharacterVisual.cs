using System;
using UnityEngine;

namespace Homework18
{
    public class CharacterVisual : MonoBehaviour
    {
        private protected Animator Animator;
        private protected EnemyMover Mover;
        
        private const string AnimationParameterSpeed = "Speed";
        private Quaternion _rotationLeft = Quaternion.Euler(0, 180, 0);
        private Quaternion _rotationRight = Quaternion.Euler(0, 0, 0);
        
        private protected void ChangeAnimation(Vector2 vector2D)
        {
            Animator.SetFloat(AnimationParameterSpeed, Math.Abs(vector2D.x));
        }
        
        private protected void FlipSprite(Vector2 vector2D)
        {
            if (vector2D.x < 0)
                transform.rotation = _rotationLeft;
            else if(vector2D.x > 0)
                transform.rotation = _rotationRight;
        }
    }
}