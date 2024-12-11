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
            WaitForSeconds wait = new WaitForSeconds(1f);
            _sliderSmoothView.Initialize(_spell.Cooldown);
            
            float startTime = Time.time;
            float currentTime = 0;

            while (currentTime < _spell.Cooldown)
            {
                currentTime = Time.time - startTime;
                
                _sliderSmoothView.UpdateValue(_spell.Cooldown - currentTime);
                
                yield return wait;
            }
            
            _sliderSmoothView.UpdateValue(0);
            _isEnable = true;
        }

        private void CastSpell()
        {
            if (_isEnable)
                _spell.Use(_sliderSmoothView);
            
            _isEnable = false;
        }
    }
}