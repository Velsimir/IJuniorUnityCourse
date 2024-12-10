using UnityEngine;
using UnityEngine.UI;

namespace Homework18
{
    [RequireComponent(typeof(Slider))]
    public class SliderView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Health _health;
        
        private Slider _slider;
        private float _sliderPercent;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _sliderPercent = (_slider.maxValue - _slider.minValue) / 100;
        }

        private void Start()
        {
            _slider.value = TransferToSliderValue(_health.MaxHealth);
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
            _slider.value = TransferToSliderValue(_health.CurrentHealth);
        }

        private float TransferToSliderValue(float value)
        {
            float currentHealthPercent = (value / _health.MaxHealth) * 100;
            
            return currentHealthPercent * _sliderPercent;
        }
    }
}