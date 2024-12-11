using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Homework18
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private InputSystem _inputSystem;
        
        public Action<Vector2> MoveButtonPressed;
        public Action JumpButtonPressed;
        public Action AttackedButtonPressed;

        private void Awake()
        {
            _inputSystem = new InputSystem();
        }

        private void OnEnable()
        {
            _inputSystem.Player.Move.performed += OnMove;
            _inputSystem.Player.Move.canceled += OnMove;
            _inputSystem.Player.Jump.performed += OnJump;
            _inputSystem.Player.Attack.performed += OnAttack;
            _inputSystem.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.Player.Move.performed -= OnMove;
            _inputSystem.Player.Move.canceled += OnMove;
            _inputSystem.Player.Jump.performed -= OnJump;
            _inputSystem.Player.Attack.performed -= OnAttack;
            _inputSystem.Disable();
        }

        private void OnMove(InputAction.CallbackContext obj)
        {
            MoveButtonPressed?.Invoke(obj.ReadValue<Vector2>());
        }
        
        private void OnJump(InputAction.CallbackContext obj)
        {
            JumpButtonPressed?.Invoke();
        }

        private void OnAttack(InputAction.CallbackContext obj)
        {
            AttackedButtonPressed?.Invoke();
        }
    }
}