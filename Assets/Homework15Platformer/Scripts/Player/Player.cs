using UnityEngine;

namespace Homework15
{
    [RequireComponent(typeof(PlayerCharacteristic))]
    public class Player : MonoBehaviour
    {
        private PlayerCharacteristic _characteristic;
        private int _health;
        
        public bool IsOnFloor { get; private set; } = true;
        public int Damage { get; private set; }

        private void Awake()
        {
            _characteristic = GetComponent<PlayerCharacteristic>();
            Damage = _characteristic.Damage;
            _health = _characteristic.MaxHealth;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Floor floor))
                IsOnFloor = true;

            if (collision.transform.TryGetComponent(out Enemy enemy))
                TakeDamage(enemy.Damage);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out Item item))
            {
                switch (item)
                {
                    case Coin coin:
                        coin.Collect();
                        break;
                    
                    case HealthBag healthBag:
                        healthBag.Collect();
                        IncreaseHealth(healthBag.Value);
                        break;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Floor floor))
                IsOnFloor = false;
        }

        private void IncreaseHealth(int amount)
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