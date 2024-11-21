using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerCharacteristic))]
    public class Player : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D { get; private set; }
        public bool IsOnFloor { get; private set; } = true;
        
        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent<Floor>(out Floor floor))
                IsOnFloor = true;
        }
        
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent<Floor>(out Floor floor))
                IsOnFloor = false;
        }
    }
}