using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Characteristic))]
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerMover : MonoBehaviour
    {
        private Characteristic _playerCharacteristic;
        private PlayerInputHandler _playerInputHandler;
        private Player _player;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _directon;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _player = GetComponent<Player>();
            _playerCharacteristic = GetComponent<Characteristic>();
            _playerInputHandler = GetComponent<PlayerInputHandler>();
        }

        private void OnEnable()
        {
            _playerInputHandler.MoveButtonPressed += SetDirection;
            _playerInputHandler.JumpButtonPressed += Jump;
        }

        private void Update()
        {
            Move();
        }

        private void OnDisable()
        {
            _playerInputHandler.MoveButtonPressed -= SetDirection;
            _playerInputHandler.JumpButtonPressed -= Jump;
        }

        private void SetDirection(Vector2 directon)
        {
            _directon = new Vector2(directon.x, 0);
        }

        private void Jump()
        {
            if (_player.IsOnFloor)
                _rigidbody2D.AddForce(Vector2.up * _playerCharacteristic.JumpForce, ForceMode2D.Impulse);
        }

        private void Move()
        {
            _rigidbody2D.linearVelocity =
                new Vector2(_directon.x * _playerCharacteristic.Speed, _rigidbody2D.linearVelocity.y);
        }
    }
}