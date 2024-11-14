using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Homework14
{
    public class InputHandler : MonoBehaviour
    {
        private InputSystem _inputSystem;

        public event Action<Vector2> DirectionChanging; 

        private void Awake()
        {
            _inputSystem = new InputSystem();
        }

        private void OnEnable()
        {
            _inputSystem.Player.Move.performed += OnMove;
            _inputSystem.Player.Move.canceled += OnMove;
            _inputSystem.Enable();
        }
        
        private void OnDisable()
        {
            _inputSystem.Player.Move.performed -= OnMove;
            _inputSystem.Player.Move.canceled -= OnMove;
            _inputSystem.Disable();
        }

        private void OnMove(InputAction.CallbackContext input)
        {
            DirectionChanging?.Invoke(input.ReadValue<Vector2>());
        }
    }
}