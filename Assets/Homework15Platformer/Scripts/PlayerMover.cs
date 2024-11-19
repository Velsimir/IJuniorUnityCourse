using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(Player))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        
        private Player _player;
        private Vector2 _directon;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            Move();
        }

        public void SetDirecton(Vector2 directon)
        {
            _directon = new Vector2(directon.x, 0);
        }

        public void Jump()
        {
            if (_player.IsOnFloor)
                _player.Rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void Move()
        {
            transform.Translate(_directon * (_speed *Time.deltaTime));
        }
    }
}