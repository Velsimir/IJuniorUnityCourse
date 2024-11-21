using System;
using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(PlayerCharacteristic))]
    public class PlayerMover : MonoBehaviour
    {
        private PlayerCharacteristic _playerCharacteristic;
        private PlayerInputHandler _playerInputHandler;
        private Player _player;
        private Vector2 _directon;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _playerCharacteristic = GetComponent<PlayerCharacteristic>();
            _playerInputHandler = GetComponent<PlayerInputHandler>();
        }

        private void OnEnable()
        {
            _playerInputHandler.MoveButtonPressed += SetDirecton;
            _playerInputHandler.JumpButtonPressed += Jump;
        }

        private void Update()
        {
            Move();
        }

        private void OnDisable()
        {
            _playerInputHandler.MoveButtonPressed -= SetDirecton;
            _playerInputHandler.JumpButtonPressed -= Jump;
        }

        public void SetDirecton(Vector2 directon)
        {
            _directon = new Vector2(directon.x, 0);
        }

        public void Jump()
        {
            if (_player.IsOnFloor)
                _player.Rigidbody2D.AddForce(Vector2.up * _playerCharacteristic.JumpForce, ForceMode2D.Impulse);
        }

        private void Move()
        {
            transform.Translate(_directon * (_playerCharacteristic.Speed *Time.deltaTime));
        }
    }
}