using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Homework18
{
    public class SliderSmoothView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Health _health;
        [SerializeField] private float _speed;
        
        private Slider _slider;
        private float _sliderPercent;
        private Coroutine _coroutineChangeValue;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _sliderPercent = (_slider.maxValue - _slider.minValue) / 100;
        }

        private void Start()
        {
            UpdateHealth();
        }

        private void OnEnable()
        {
            _health.HealthChanged += UpdateHealth;
        }
        
        private void OnDisable()
        {
            _health.HealthChanged -= UpdateHealth;
        }

        public void UpdateHealth()
        {
            if (_coroutineChangeValue != null)
            {
                StopCoroutine(_coroutineChangeValue);
                _coroutineChangeValue = null;
            }
            
            _coroutineChangeValue = StartCoroutine(ChangeValue());
        }

        private float TransferToSliderValue(float value)
        {
            float currentHealthPercent = (value / _health.MaxHealth) * 100;
            
            return currentHealthPercent * _sliderPercent;
        }
        
        private IEnumerator ChangeValue()
        {
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
            
            while (true)
            {
                _slider.value = Mathf.MoveTowards(_slider.value,TransferToSliderValue(_health.CurrentHealth), Time.deltaTime * _speed);
                
                yield return wait;
            }
        }
    }
}