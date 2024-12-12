using System.Collections;
using UnityEngine;

namespace Homework18
{
    [RequireComponent(typeof(PlayerInputHandler))]
    public class SpellCaster : MonoBehaviour
    {
        [SerializeField] private Spell _spell;
        [SerializeField] private SliderSmoothView _sliderSmoothView;
        
        private PlayerInputHandler _inputHandler;
        private Coroutine _coroutineCooldown;
        private bool _isEnable = true;

        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
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
            
            _sliderSmoothView.UpdateValue(_spell.Cooldown, 0f, _spell.Cooldown);
            
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
                _spell.Use();
                _sliderSmoothView.UpdateValue(_spell.Duration, _spell.Duration, _spell.Duration);
            }
            
            _isEnable = false;
        }
    }
}