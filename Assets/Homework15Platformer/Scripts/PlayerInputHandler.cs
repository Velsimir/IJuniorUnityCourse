using UnityEngine;
using UnityEngine.InputSystem;

namespace Homework15
{
    [RequireComponent(typeof(PlayerMover))]
    public class PlayerInputHandler : MonoBehaviour
    {
        private InputSystem _inputSystem;
        private PlayerMover _playerMover;

        private void Awake()
        {
            _inputSystem = new InputSystem();
            _playerMover = GetComponent<PlayerMover>();
        }

        private void OnEnable()
        {
            _inputSystem.Player.Move.performed += OnMove;
            _inputSystem.Player.Move.canceled += OnMove;
            _inputSystem.Player.Jump.performed += OnJump;
            _inputSystem.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.Player.Move.performed -= OnMove;
            _inputSystem.Player.Move.canceled += OnMove;
            _inputSystem.Player.Jump.performed -= OnJump;
            _inputSystem.Disable();
        }

        private void OnMove(InputAction.CallbackContext obj)
        {
            _playerMover.SetDirecton(obj.ReadValue<Vector2>());
        }
        
        private void OnJump(InputAction.CallbackContext obj)
        {
            _playerMover.Jump();
        }
    }
}
