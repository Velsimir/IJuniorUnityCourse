using UnityEngine;
using UnityEngine.UI;

namespace Homework18
{
    [RequireComponent(typeof(Slider))]
    public class SliderView : MonoBehaviour, ISliderView
    {
        private float _maxValue;
        private Slider _slider;
        private float _sliderPercent;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _sliderPercent = (_slider.maxValue - _slider.minValue) / 100;
        }

        private void Start()
        {
            _slider.value = TransferToSliderValue(_maxValue);
        }

        public void UpdateValue(float value)
        {
            _slider.value = TransferToSliderValue(value);
        }

        private float TransferToSliderValue(float value)
        {
            float currentHealthPercent = (value / _maxValue) * 100;
            
            return currentHealthPercent * _sliderPercent;
        }
    }
}