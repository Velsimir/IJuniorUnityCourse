using UnityEngine;

namespace Homework15
{
    public class Enemy : MonoBehaviour
    {
        private int _health = 2;
        private EnemyCharacteristic _characteristic;
        public int Damage { get; private set; }

        private void Awake()
        {
            _characteristic = GetComponent<EnemyCharacteristic>();
            _health = _characteristic.MaxHealth;
            Damage = _characteristic.Damage;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Player player))
                TakeDamage(player.Damage);
        }

        private void TakeDamage(int damage)
        {
            if (_health - damage < 0)
                Death();
            else
                _health -= damage;
        }

        private void Death()
        {
            Destroy(this.gameObject);
        }
    }
}