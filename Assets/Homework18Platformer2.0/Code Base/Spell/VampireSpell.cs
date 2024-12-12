using System.Collections;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class VampireSpell : Spell
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _duration;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _tickInterval;
        [SerializeField] private int _damage;
        [SerializeField] private Player _player;

        private Coroutine _coroutineSpell;
        private SpriteRenderer _circleRenderer;
        private Color _circleColorDefault;
        private Color _circleColorAlpha0 = new Color(1, 1, 1, 0);
        
        private void Awake()
        {
            Duration = _duration;
            Cooldown = _cooldown;
            _circleRenderer = GetComponent<SpriteRenderer>();
            _circleRenderer.transform.localScale = new Vector3(_radius * 2, _radius * 2, 1f);
            _circleColorDefault = _circleRenderer.color;
            _circleRenderer.color = _circleColorAlpha0;
        }
        
        public override void Use()
        {
            if (_coroutineSpell != null)
            {
                StopCoroutine(_coroutineSpell);
                _coroutineSpell = null;
            }

            _coroutineSpell = StartCoroutine(Cast());
        }

        protected override IEnumerator Cast()
        {
            WaitForSeconds wait = new WaitForSeconds(_tickInterval);
            float currentTime = 0f;
                
            _circleRenderer.color = _circleColorDefault;

            while (currentTime < _duration)
            {
                currentTime += _tickInterval;
                MakeVampirize();
                    
                yield return wait;
            }
                
            SendCastFinished();
                
            _circleRenderer.color = _circleColorAlpha0;
        }

        private void MakeVampirize()
        {
            Enemy enemy = FindClosestEnemy();

            if (enemy != null)
            {
                if (enemy.CurrentHealth - _damage >= 0)
                {
                    enemy.TakeDamage(_damage);
                    _player.IncreaseHealth(_damage);
                }
                else
                {
                    enemy.TakeDamage(_damage);
                    _player.IncreaseHealth(enemy.CurrentHealth);
                }

            }
        }

        private Enemy FindClosestEnemy()
        {
            Collider2D[] _colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
            Enemy closestEnemy = null;
            float closestDistance = float.MaxValue;
            
            foreach (var collider in _colliders)
            {
                if (collider.TryGetComponent(out Enemy enemy))
                {
                    if (closestDistance > Vector2.Distance(_player.transform.position, enemy.transform.position))
                        closestEnemy = enemy;
                }
            }
            
            return closestEnemy;
        }
    }
}