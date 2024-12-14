using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour, IDamageable, IDamageDealer, ICharacteristic
    {
        [SerializeField] private CharacteristicSo _characteristic;
        
        private Health _health;
        private float _damage;
        
        public float CurrentHealth => _health.CurrentHealth;
        public float Damage => _damage;
        public Health Health => _health;
        public CharacteristicSo CharacteristicSo => _characteristic;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _health.SetMaxHealth(_characteristic.MaxHealth);
            _damage = _characteristic.Damage;
        }

        private void OnEnable()
        {
            _health.HealthEnded += Die;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out IDamageDealer damageDealer))
                TakeDamage(damageDealer.Damage);
        }
        
        private void OnDisable()
        {
            _health.HealthEnded -= Die;
        }

        public void TakeDamage(float damage)
        {
            _health.Decrease(damage);
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}