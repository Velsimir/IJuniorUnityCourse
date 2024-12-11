using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Characteristic))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(ItemCatcher))]
    public class Player : MonoBehaviour
    {
        private Characteristic _characteristic;
        private Health _health;
        
        public bool IsOnFloor { get; private set; } = true;
        public int Damage { get; private set; }

        private void Awake()
        {
            _characteristic = GetComponent<Characteristic>();
            _health = GetComponent<Health>();
            Damage = _characteristic.Damage;
            _health.SetMaxHealth(_characteristic.MaxHealth);
        }

        private void OnEnable()
        {
            _health.HealthEnded += Die;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Floor floor))
                IsOnFloor = true;

            if (collision.transform.TryGetComponent(out Enemy enemy))
                TakeDamage(enemy.Damage);
        }

        private void OnDisable()
        {
            _health.HealthEnded -= Die;
        }
        
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Floor floor))
                IsOnFloor = false;
        }

        public void IncreaseHealth(int value)
        {
            _health.Increase(value);
        }

        private void TakeDamage(int damage)
        {
            _health.Decrease(damage);
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}