using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Homework8
{
    public class RaycastClickHandler : MonoBehaviour
    {
        public event Action<RaycastHit[]> RaycastsGot;
        private Ray _mouseRay;
        private InputSystem _inputSystem;

        private void Awake()
        {
            _inputSystem = new InputSystem();
        }

        private void OnEnable()
        {
            _inputSystem.Player.Attack.performed += MakeRaycast;
            _inputSystem.Enable();
        }
        
        private void OnDisable()
        {
            _inputSystem.Player.Attack.performed -= MakeRaycast;
            _inputSystem.Disable();
        }

        private void MakeRaycast(InputAction.CallbackContext obj)
        {
            _mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] allHitsRaycast = Physics.RaycastAll(_mouseRay);
            
            RaycastsGot?.Invoke(allHitsRaycast);
        }
    }
}