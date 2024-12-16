using System;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(EnemyMover))]
    public class EnemyVisual : CharacterVisual
    {
        private void Awake()
        {
            Animator = GetComponent<Animator>();
            Mover = GetComponent<EnemyMover>();
        }

        private void OnEnable()
        {
            Mover.DirectionChanged += FlipSprite;
            Mover.DirectionChanged += ChangeAnimation;
        }

        private void OnDisable()
        {
            Mover.DirectionChanged -= FlipSprite;
            Mover.DirectionChanged -= ChangeAnimation;
        }
    }
}