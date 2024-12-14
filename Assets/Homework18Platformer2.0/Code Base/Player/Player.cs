using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(ItemCatcher))]
    public class Player : MonoBehaviour, IDamageable, IHealable, IDamageDealer, ITarget, ICharacteristic
    {
        [SerializeField] private CharacteristicSo _characteristicSo;
        
        private Health _health;
        private int _damage;
        private ItemCatcher _itemCatcher;
        
        public bool IsOnFloor { get; private set; } = true;
        public float Damage => _damage;
        public Transform Transform => transform;
        public CharacteristicSo CharacteristicSo => _characteristicSo;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _damage = _characteristicSo.Damage;
            _health.SetMaxHealth(_characteristicSo.MaxHealth);
            _itemCatcher = GetComponent<ItemCatcher>();
        }

        private void OnEnable()
        {
            _health.HealthEnded += Die;
            _itemCatcher.ItemCatched += CatchItem;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Floor floor))
                IsOnFloor = true;

            if (collision.transform.TryGetComponent(out IDamageDealer damageDealer))
                TakeDamage(damageDealer.Damage);
        }

        private void OnDisable()
        {
            _health.HealthEnded -= Die;
            _itemCatcher.ItemCatched -= CatchItem;
        }
        
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out Floor floor))
                IsOnFloor = false;
        }

        public void IncreaseHealth(float value)
        {
            _health.Increase(value);
        }

        public void TakeDamage(float damage)
        {
            _health.Decrease(damage);
        }

        private void Die()
        {
            Destroy(gameObject);
        }
        
        private void CatchItem(Item item)
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

    public interface IHealable
    {
        public void IncreaseHealth(float value);
    }
}