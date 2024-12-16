using System;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerVisual : CharacterVisual
    {
        private PlayerInputHandler _inputHandler;

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            _inputHandler = GetComponent<PlayerInputHandler>();
        }

        private void OnEnable()
        {
            _inputHandler.MoveButtonPressed += ChangeAnimation;
            _inputHandler.MoveButtonPressed += FlipSprite;
        }
        
        private void OnDisable()
        {
            _inputHandler.MoveButtonPressed -= ChangeAnimation;
            _inputHandler.MoveButtonPressed -= FlipSprite;
        }
    }
}