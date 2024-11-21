using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(Player))]
    public class PlayerCharacteristic : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        
        public float Speed => _speed;
        public float JumpForce => _jumpForce;
    }
}