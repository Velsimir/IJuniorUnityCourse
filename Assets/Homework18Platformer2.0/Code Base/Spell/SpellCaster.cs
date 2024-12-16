using System;
using System.Collections;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(PlayerInputHandler))]
    public class SpellCaster : MonoBehaviour, IValueProvide
    {
        [SerializeField] private Spell _spell;
        [SerializeField] private Player _player;
        [SerializeField] private SliderSmoothView _sliderSmoothView;
        
        private PlayerInputHandler _inputHandler;
        private Coroutine _coroutineCooldown;
        private bool _isEnable = true;
        
        public event Action<float, float, float> ValueChanged;

        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _sliderSmoothView.Initialize(this);
        }

        private void OnEnable()
        {
            _inputHandler.AttackedButtonPressed += CastSpell;
            _spell.CastFinished += ShowCooldown;
        }

        private void OnDisable()
        {
            _inputHandler.AttackedButtonPressed -= CastSpell;
            _spell.CastFinished -= ShowCooldown;
        }

        private void ShowCooldown()
        {
            if (_coroutineCooldown != null)
            {
                StopCoroutine(_coroutineCooldown);
                _coroutineCooldown = null;
            }
            
            _coroutineCooldown = StartCoroutine(Cooldown());
        }

        private IEnumerator Cooldown()
        {
            float oneSecond = 1.0f;
            
            WaitForSeconds wait = new WaitForSeconds(oneSecond);
            
            ValueChanged?.Invoke(_spell.Cooldown, 0f, _spell.Cooldown);
            
            float currentTime = 0;

            while (currentTime < _spell.Cooldown)
            {
                currentTime += oneSecond;
                
                yield return wait;
            }
            
            _isEnable = true;
        }

        private void CastSpell()
        {
            if (_isEnable)
            {
                _spell.Use(_player);
                ValueChanged?.Invoke(_spell.Duration, _spell.Duration, _spell.Duration);
            }
            
            _isEnable = false;
        }

    }
}