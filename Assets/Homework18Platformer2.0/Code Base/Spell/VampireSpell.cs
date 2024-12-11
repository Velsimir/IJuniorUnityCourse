using System.Collections;
using System.Collections.Generic;
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
        private Coroutine _coroutineCooldown;
        private SpriteRenderer _circleRenderer;
        private Color _circleColorDefault;
        private Color _circleColorAlpha0 = new Color(1, 1, 1, 0);
        
        private void Awake()
        {
            Cooldown = _cooldown;
            _circleRenderer = GetComponent<SpriteRenderer>();
            _circleRenderer.transform.localScale = new Vector3(_radius * 2, _radius * 2, 1f);
            _circleColorDefault = _circleRenderer.color;
            _circleRenderer.color = _circleColorAlpha0;
        }
        
        public override void Use(SliderSmoothView sliderSmoothView)
        {
            if (_coroutineSpell != null)
            {
                StopCoroutine(_coroutineSpell);
                _coroutineSpell = null;
            }

            _coroutineSpell = StartCoroutine(Cast(sliderSmoothView));
        }

        protected override IEnumerator Cast(SliderSmoothView sliderSmoothView)
        {
            WaitForSeconds wait = new WaitForSeconds(_tickInterval);
            sliderSmoothView.Initialize(_duration);
                
            float startTime = Time.time;
            float currentTime = 0;
            
            _circleRenderer.color = _circleColorDefault;

            while (currentTime < _duration)
            {
                currentTime = Time.time - startTime;
                    
                sliderSmoothView.UpdateValue(currentTime);
                    
                MakeVampirize();
                    
                yield return wait;
            }
                
            SendCastFinished();
                
            _circleRenderer.color = _circleColorAlpha0;
        }

        private void MakeVampirize()
        {
            foreach (var enemy in FindEnemies())
            {
                enemy.TakeDamage(_damage);
                _player.IncreaseHealth(_damage);
            }
        }

        private List<Enemy> FindEnemies()
        {
            Collider2D[] _colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
            List<Enemy> enemies = new List<Enemy>();
            
            foreach (var collider in _colliders)
            {
                if (collider.TryGetComponent(out Enemy enemy))
                    enemies.Add(enemy);
            }
            
            return enemies;
        }
    }
}