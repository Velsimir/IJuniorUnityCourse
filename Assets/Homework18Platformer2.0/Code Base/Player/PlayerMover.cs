using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerMover : MonoBehaviour
    {
        private CharacteristicSo _characteristic;
        private PlayerInputHandler _playerInputHandler;
        private Player _player;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _direction;

        private void Awake()
        {
            _characteristic = GetComponent<ICharacteristic>().CharacteristicSo;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _player = GetComponent<Player>();
            _playerInputHandler = GetComponent<PlayerInputHandler>();
        }

        private void OnEnable()
        {
            _playerInputHandler.MoveButtonPressed += SetDirection;
            _playerInputHandler.JumpButtonPressed += Jump;
        }

        private void FixedUpdate()
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
            _direction = new Vector2(directon.x, 0);
        }

        private void Jump()
        {
            if (_player.IsOnFloor)
                _rigidbody2D.AddForce(Vector2.up * _characteristic.JumpForce, ForceMode2D.Impulse);
        }

        private void Move()
        {
            _rigidbody2D.linearVelocity =
                new Vector2(_direction.x * _characteristic.Speed, _rigidbody2D.linearVelocity.y);
        }
    }
}