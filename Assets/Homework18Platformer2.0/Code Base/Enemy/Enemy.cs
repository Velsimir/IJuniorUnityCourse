using System;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Characteristic))]
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        private Health _health;
        private Characteristic _characteristic;
        public int Damage { get; private set; }

        private void Awake()
        {
            _characteristic = GetComponent<Characteristic>();
            _health = GetComponent<Health>();
            _health.SetMaxHealth(_characteristic.MaxHealth);
            Damage = _characteristic.Damage;
        }

        private void OnEnable()
        {
            _health.HealthEnded += Die;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Player player))
                TakeDamage(player.Damage);
        }
        
        private void OnDisable()
        {
            _health.HealthEnded -= Die;
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