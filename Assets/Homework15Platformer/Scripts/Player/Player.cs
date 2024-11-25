using UnityEngine;

namespace Homework15
{
    public class Player : MonoBehaviour
    {
        private PlayerCharacteristic _characteristic;
        private int _health;
        private int _damage;
        public bool IsOnFloor { get; private set; } = true;
        public int Damage => _damage;

        private void Awake()
        {
            _characteristic = GetComponent<PlayerCharacteristic>();
            _damage = _characteristic.Damage;
            _health = _characteristic.MaxHealth;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Floor floor))
                IsOnFloor = true;

            if (collision.transform.TryGetComponent(out Enemy enemy))
                TakeDamage(enemy.Damage);
        }
        
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Floor floor))
                IsOnFloor = false;
        }

        public void IncreaseHealth(int amount)
        {
            if (amount + _health > _characteristic.MaxHealth)
                _health = _characteristic.MaxHealth;
            else
                _health += amount;
        }

        private void TakeDamage(int damage)
        {
            if (_health - damage < 0)
                _health = 0;
            else
                _health -= damage;
        }
    }
}